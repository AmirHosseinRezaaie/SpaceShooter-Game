"use client";

import { useEffect, useRef } from "react";

export type GameConfig = {
  ship: string;
  speed: number;
  fireRate: number;
  difficulty: number;
  health: number;
  effects: boolean;
  sfx: boolean;
  sfxVolume: number;
  music: boolean;
  musicVolume: number;
};

type Props = {
  config: GameConfig;
  active: boolean;
  restartKey: number;
  onStats: (stats: { score: number; wave: number; health: number; coins: number }) => void;
};

const BASE = process.env.NEXT_PUBLIC_BASE_PATH ?? "";

export default function GameCanvas({ config, active, restartKey, onStats }: Props) {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const configRef = useRef(config);
  const musicRef = useRef<HTMLAudioElement | null>(null);
  const soundsRef = useRef<Record<string, HTMLAudioElement>>({});

  configRef.current = config;

  useEffect(() => {
    const music = new Audio(`${BASE}/game/music.wav`);
    music.loop = true;
    music.volume = configRef.current.musicVolume / 100;
    musicRef.current = music;
    soundsRef.current = {
      coin: new Audio(`${BASE}/game/coin.wav`),
      hit: new Audio(`${BASE}/game/hit.wav`),
      boom: new Audio(`${BASE}/game/explosion.wav`),
    };
    return () => {
      music.pause();
      musicRef.current = null;
      Object.values(soundsRef.current).forEach((audio) => audio.pause());
    };
  }, []);

  useEffect(() => {
    const music = musicRef.current;
    if (!music) return;
    music.volume = config.musicVolume / 100;
    if (config.music && active) void music.play().catch(() => undefined);
    else music.pause();
  }, [config.music, config.musicVolume, active]);

  useEffect(() => {
    const canvas = canvasRef.current;
    const ctx = canvas?.getContext("2d");
    if (!canvas || !ctx || !active) return;

    const W = 900;
    const H = 540;
    const image = (name: string) => {
      const item = new Image();
      item.src = `${BASE}/game/${name}`;
      return item;
    };
    const art = {
      background: image("background.png"),
      player: image(configRef.current.ship),
      standard: image("enemy-standard.png"),
      scout: image("enemy-scout.png"),
      shooter: image("enemy-shooter.png"),
      terrorist: image("enemy-terrorist.png"),
      tank: image("enemy-tank.png"),
      bullet: image("player-bullet.png"),
      enemyBullet: image("enemy-bullet.png"),
      coin: image("coin.png"),
      health: image("health.png"),
      shield: image("shield.png"),
      tripleShot: image("triple-shot.png"),
    };
    const keys = new Set<string>();
    const player = { x: W / 2, y: H - 88, w: 76, h: 76 };
    let bullets: { x: number; y: number; vx: number; vy: number }[] = [];
    let enemyBullets: { x: number; y: number; vy: number }[] = [];
    let enemies: { x: number; y: number; hp: number; maxHp: number; speed: number; kind: string; phase: number; lastShot: number }[] = [];
    let coins: { x: number; y: number }[] = [];
    let powerUps: { x: number; y: number; kind: string }[] = [];
    let particles: { x: number; y: number; life: number; color: string }[] = [];
    let stars = Array.from({ length: 95 }, () => ({ x: Math.random() * W, y: Math.random() * H, z: Math.random() * 1.8 + 0.4 }));
    let score = 0;
    let wave = 1;
    let health = configRef.current.health;
    let shieldUntil = 0;
    let tripleUntil = 0;
    let collected = 0;
    let spawned = 0;
    let spawnClock = 0;
    let lastShot = 0;
    let lastStats = 0;
    let frame = 0;
    let animation = 0;
    let stopped = false;
    let previousHealthSetting = configRef.current.health;

    const playSound = (name: string) => {
      const current = configRef.current;
      if (!current.sfx) return;
      const sound = soundsRef.current[name];
      if (!sound) return;
      sound.volume = current.sfxVolume / 100;
      sound.currentTime = 0;
      void sound.play().catch(() => undefined);
    };
    const reset = () => {
      bullets = [];
      enemyBullets = [];
      enemies = [];
      coins = [];
      powerUps = [];
      particles = [];
      score = 0;
      wave = 1;
      health = configRef.current.health;
      shieldUntil = 0;
      tripleUntil = 0;
      collected = 0;
      spawned = 0;
      spawnClock = 0;
      onStats({ score, wave, health, coins: collected });
    };
    reset();

    const keyDown = (event: KeyboardEvent) => {
      if (event.target instanceof HTMLElement && event.target.closest("input, textarea, select, [contenteditable='true']")) return;
      const key = event.key.toLowerCase();
      if (["arrowup", "arrowdown", "arrowleft", "arrowright", " "].includes(key)) event.preventDefault();
      keys.add(key);
    };
    const keyUp = (event: KeyboardEvent) => keys.delete(event.key.toLowerCase());
    window.addEventListener("keydown", keyDown);
    window.addEventListener("keyup", keyUp);

    const drawImage = (img: HTMLImageElement, x: number, y: number, w: number, h: number) => {
      if (img.complete && img.naturalWidth > 0) ctx.drawImage(img, x, y, w, h);
    };
    const loop = (time: number) => {
      if (stopped) return;
      const current = configRef.current;
      frame++;
      if (art.player.src !== new URL(`${BASE}/game/${current.ship}`, window.location.href).href) art.player.src = `${BASE}/game/${current.ship}`;
      if (previousHealthSetting !== current.health) {
        health = current.health;
        previousHealthSetting = current.health;
      }
      ctx.clearRect(0, 0, W, H);
      ctx.fillStyle = "#050a18";
      ctx.fillRect(0, 0, W, H);
      drawImage(art.background, 0, 0, W, H);
      stars.forEach((star) => {
        star.y += star.z * (current.effects ? 1.5 : 0.75);
        if (star.y > H) { star.y = 0; star.x = Math.random() * W; }
        ctx.globalAlpha = 0.35 + star.z / 3;
        ctx.fillStyle = "#d9f7ff";
        ctx.fillRect(star.x, star.y, star.z * 1.4, star.z * 1.4);
      });
      ctx.globalAlpha = 1;

      const speed = current.speed * 0.9;
      if (keys.has("arrowleft") || keys.has("a")) player.x -= speed;
      if (keys.has("arrowright") || keys.has("d")) player.x += speed;
      if (keys.has("arrowup") || keys.has("w")) player.y -= speed;
      if (keys.has("arrowdown") || keys.has("s")) player.y += speed;
      player.x = Math.max(8, Math.min(W - player.w - 8, player.x));
      player.y = Math.max(95, Math.min(H - player.h - 8, player.y));
      if ((keys.has(" ") || keys.has("space")) && time - lastShot > current.fireRate * 1000) {
        if (frame < tripleUntil) {
          bullets.push({ x: player.x + 18, y: player.y + 7, vx: -2.1, vy: -10.5 });
          bullets.push({ x: player.x + player.w / 2 - 3, y: player.y + 5, vx: 0, vy: -11 });
          bullets.push({ x: player.x + player.w - 24, y: player.y + 7, vx: 2.1, vy: -10.5 });
        } else {
          bullets.push({ x: player.x + player.w / 2 - 3, y: player.y + 5, vx: 0, vy: -11 });
        }
        lastShot = time;
      }

      spawnClock++;
      const spawnEvery = Math.max(20, 50 / current.difficulty);
      const enemiesPerWave = 3 + wave * 2;
      if (spawnClock >= spawnEvery && spawned < enemiesPerWave) {
        const roll = Math.random();
        let kind: string;
        if (wave <= 3) kind = roll < 0.7 ? "standard" : "scout";
        else if (wave <= 6) kind = roll < 0.5 ? "standard" : roll < 0.75 ? "scout" : "shooter";
        else if (wave <= 9) kind = roll < 0.3 ? "standard" : roll < 0.55 ? "scout" : roll < 0.85 ? "shooter" : "terrorist";
        else kind = roll < 0.2 ? "standard" : roll < 0.4 ? "scout" : roll < 0.7 ? "shooter" : roll < 0.9 ? "terrorist" : "tank";
        const hp = kind === "tank" ? 16 : kind === "terrorist" ? 11 : kind === "shooter" ? 4 : 2;
        const baseSpeed = kind === "tank" ? 1 : kind === "scout" ? 3 : 2;
        enemies.push({ x: 36 + Math.random() * (W - 100), y: -72, hp, maxHp: hp, speed: baseSpeed * (1 + 0.1 * wave) * current.difficulty, kind, phase: Math.random() * 6, lastShot: frame });
        spawned++;
        spawnClock = 0;
      }
      if (spawned >= enemiesPerWave && enemies.length === 0) {
        wave++;
        spawned = 0;
        score += 60;
      }

      bullets = bullets.filter((bullet) => bullet.y > -24);
      bullets.forEach((bullet) => {
        bullet.x += bullet.vx;
        bullet.y += bullet.vy;
        drawImage(art.bullet, bullet.x, bullet.y, 12, 26);
      });

      enemies = enemies.filter((enemy) => enemy.y < H + 90 && enemy.hp > 0);
      enemies.forEach((enemy) => {
        enemy.y += enemy.speed;
        if (enemy.kind === "scout") enemy.x += Math.sin(frame / 24 + enemy.phase) * 1.6;
        if (enemy.kind === "terrorist") {
          const dx = player.x + player.w / 2 - (enemy.x + 25);
          const dy = player.y + player.h / 2 - (enemy.y + 25);
          const distance = Math.hypot(dx, dy) || 1;
          enemy.x += dx / distance * enemy.speed;
          enemy.y += dy / distance * enemy.speed;
        }
        const enemyImage = enemy.kind === "tank" ? art.tank : enemy.kind === "terrorist" ? art.terrorist : enemy.kind === "shooter" ? art.shooter : enemy.kind === "scout" ? art.scout : art.standard;
        const size = enemy.kind === "tank" ? 72 : enemy.kind === "terrorist" ? 52 : 48;
        drawImage(enemyImage, enemy.x, enemy.y, size, size);
        if ((enemy.kind === "shooter" || enemy.kind === "tank") && frame - enemy.lastShot > (enemy.kind === "tank" ? 175 : 75) / current.difficulty) {
          enemyBullets.push({ x: enemy.x + size / 2, y: enemy.y + size, vy: 4.2 * current.difficulty });
          enemy.lastShot = frame;
        }
        if (enemy.maxHp > 1) {
          ctx.fillStyle = "#391e3a"; ctx.fillRect(enemy.x, enemy.y - 8, size, 4);
          ctx.fillStyle = "#fb7185"; ctx.fillRect(enemy.x, enemy.y - 8, size * enemy.hp / enemy.maxHp, 4);
        }
        if (enemy.y > player.y - 14 && enemy.y < player.y + player.h - 10 && enemy.x < player.x + player.w - 8 && enemy.x + size > player.x + 8) {
          enemy.y = H + 100;
          if (frame >= shieldUntil) {
            health = Math.max(0, health - 1);
            playSound("hit");
            if (current.effects) for (let i = 0; i < 12; i++) particles.push({ x: player.x + 38, y: player.y + 38, life: 28, color: "#fb7185" });
          }
        }
      });
      enemyBullets = enemyBullets.filter((bullet) => bullet.y < H + 20);
      enemyBullets.forEach((bullet) => {
        bullet.y += bullet.vy;
        drawImage(art.enemyBullet, bullet.x - 5, bullet.y, 10, 22);
        if (frame >= shieldUntil && bullet.x > player.x + 10 && bullet.x < player.x + player.w - 10 && bullet.y > player.y + 12 && bullet.y < player.y + player.h) {
          bullet.y = H + 40;
          health = Math.max(0, health - 1);
          playSound("hit");
          if (current.effects) for (let i = 0; i < 8; i++) particles.push({ x: player.x + 38, y: player.y + 38, life: 20, color: "#fb7185" });
        }
      });

      bullets.forEach((bullet) => {
        enemies.forEach((enemy) => {
          const size = enemy.kind === "tank" ? 72 : enemy.kind === "terrorist" ? 52 : 48;
          if (bullet.x > enemy.x && bullet.x < enemy.x + size && bullet.y > enemy.y && bullet.y < enemy.y + size && enemy.hp > 0) {
            enemy.hp--;
            bullet.y = -100;
            if (enemy.hp <= 0) {
              score += enemy.kind === "tank" ? 100 : enemy.kind === "terrorist" ? 80 : enemy.kind === "shooter" ? 30 : enemy.kind === "scout" ? 20 : 10;
              const coinChance = enemy.kind === "tank" ? 0.8 : enemy.kind === "terrorist" ? 0.6 : enemy.kind === "shooter" ? 0.4 : enemy.kind === "scout" ? 0.3 : 0.2;
              if (Math.random() < coinChance) coins.push({ x: enemy.x + size / 2, y: enemy.y + size / 2 });
              else {
                const kinds = ["health", "shield", "tripleShot"];
                powerUps.push({ x: enemy.x + size / 2, y: enemy.y + size / 2, kind: kinds[Math.floor(Math.random() * kinds.length)] });
              }
              playSound("boom");
              if (current.effects) for (let i = 0; i < 13; i++) particles.push({ x: enemy.x + size / 2, y: enemy.y + size / 2, life: 24, color: "#fb923c" });
            }
          }
        });
      });
      coins = coins.filter((coin) => coin.y < H + 20);
      coins.forEach((coin) => {
        coin.y += 2.4;
        drawImage(art.coin, coin.x - 12, coin.y - 12, 24, 24);
        if (Math.abs(coin.x - (player.x + 38)) < 38 && Math.abs(coin.y - (player.y + 38)) < 42) {
          coin.y = H + 40; collected++; score += 5; playSound("coin");
        }
      });
      powerUps = powerUps.filter((item) => item.y < H + 30);
      powerUps.forEach((item) => {
        item.y += 2.1;
        const itemImage = item.kind === "shield" ? art.shield : item.kind === "tripleShot" ? art.tripleShot : art.health;
        drawImage(itemImage, item.x - 15, item.y - 15, 30, 30);
        if (Math.abs(item.x - (player.x + 38)) < 38 && Math.abs(item.y - (player.y + 38)) < 42) {
          item.y = H + 40;
          if (item.kind === "health") health = Math.min(5, health + 1);
          if (item.kind === "shield") shieldUntil = frame + 300;
          if (item.kind === "tripleShot") tripleUntil = frame + 300;
          playSound("coin");
        }
      });
      if (current.effects) {
        particles = particles.filter((particle) => particle.life > 0);
        particles.forEach((particle) => {
          particle.life--;
          ctx.globalAlpha = particle.life / 28;
          ctx.fillStyle = particle.color;
          ctx.beginPath(); ctx.arc(particle.x + (Math.random() - 0.5) * 38, particle.y + (Math.random() - 0.5) * 38, 2 + Math.random() * 3, 0, Math.PI * 2); ctx.fill();
        });
        ctx.globalAlpha = 1;
      } else particles = [];

      drawImage(art.player, player.x, player.y, player.w, player.h);
      if (frame < shieldUntil) {
        ctx.strokeStyle = "rgba(90,230,255,.9)"; ctx.lineWidth = 3;
        ctx.beginPath(); ctx.ellipse(player.x + 38, player.y + 38, 48, 49, 0, 0, Math.PI * 2); ctx.stroke();
      }
      if (health > 0) {
        ctx.fillStyle = "rgba(5, 10, 24, .76)";
        ctx.fillRect(18, 16, W - 36, 52);
        ctx.font = "700 17px Arial";
        ctx.fillStyle = "#f8fafc";
        ctx.fillText(`SCORE  ${score.toString().padStart(5, "0")}`, 38, 48);
        ctx.fillStyle = "#fbbf24"; ctx.fillText(`COINS  ${collected}`, 310, 48);
        ctx.fillStyle = "#67e8f9"; ctx.fillText(`WAVE  ${wave}`, 510, 48);
        ctx.fillStyle = "#fb7185"; ctx.fillText(`HP  ${"♥".repeat(health)}${"♡".repeat(Math.max(0, 5 - health))}`, 700, 48);
        if (frame < tripleUntil) { ctx.fillStyle = "#f0abfc"; ctx.fillText("TRIPLE SHOT", 700, 88); }
      } else {
        ctx.fillStyle = "rgba(3, 7, 18, .78)"; ctx.fillRect(0, 0, W, H);
        ctx.textAlign = "center";
        ctx.fillStyle = "#fb7185"; ctx.font = "800 54px Arial"; ctx.fillText("MISSION FAILED", W / 2, H / 2 - 8);
        ctx.fillStyle = "#dbeafe"; ctx.font = "18px Arial"; ctx.fillText("Press restart to launch another run", W / 2, H / 2 + 34);
        ctx.textAlign = "left";
      }

      if (time - lastStats > 280) {
        onStats({ score, wave, health, coins: collected });
        lastStats = time;
      }
      animation = window.requestAnimationFrame(loop);
    };
    animation = window.requestAnimationFrame(loop);

    return () => {
      stopped = true;
      window.cancelAnimationFrame(animation);
      window.removeEventListener("keydown", keyDown);
      window.removeEventListener("keyup", keyUp);
    };
  }, [active, restartKey, onStats]);

  return <canvas ref={canvasRef} className="game-canvas" width={900} height={540} aria-label="Interactive Space Shooter game preview" />;
}
