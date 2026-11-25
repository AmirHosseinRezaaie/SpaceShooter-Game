"use client";

import { useCallback, useEffect, useMemo, useState } from "react";
import GameCanvas, { type GameConfig } from "@/components/GameCanvas";

const BASE = process.env.NEXT_PUBLIC_BASE_PATH ?? "";
const asset = (path: string) => `${BASE}${path}`;

type Locale = "fa" | "en";
type Theme = "dark" | "light";
type Stats = { score: number; wave: number; health: number; coins: number };

const copy = {
  fa: {
    nav: ["شروع سفر", "جهان بازی", "موتور بازی", "منطق و محاسبات", "نتیجه", "آزمایشگاه"],
    heroEyebrow: "یک پروژه شخصی · ساخته‌شده با C#",
    heroTitle: "از یک ایده ساده، تا یک جهان در حال نبرد.",
    heroBody: "این‌جا فقط یک بازی سفینه‌ای را تماشا نمی‌کنی؛ قدم‌به‌قدم وارد دنیایی می‌شوی که از صفر طراحی، برنامه‌نویسی و زنده شده است.",
    explore: "شروع سفر در پروژه", play: "رفتن به آزمایشگاه", scroll: "برای ادامه اسکرول کن",
    chapters: [
      { eyebrow: "01 / WORLD BUILDING", title: "اول، جهان بازی شکل گرفت.", body: "قبل از اولین شلیک، باید صحنه‌ای می‌ساختیم که ارزش کشف کردن داشته باشد. پس‌زمینه فضایی، سفینه بازیکن، ناوگان دشمن و آیتم‌های ویژه کنار هم قرار گرفتند تا یک میدان نبرد زنده شکل بگیرد.", points: ["پس‌زمینه فضایی و HUD اختصاصی", "۵ ظاهر برای سفینه بازیکن", "دشمن‌ها، سکه‌ها و Power-upها"], tag: "طراحی صحنه و دارایی‌ها" },
      { eyebrow: "02 / GAME ARCHITECTURE", title: "هر دشمن، رفتار خودش را دارد.", body: "بازی با چند تصویر متحرک ساخته نشده است. هر موجود یک شیء مستقل است؛ حرکت، جان، امتیاز و شانس رها کردن آیتم دارد. Wave Manager ترکیب دشمن‌ها را با بالا رفتن مرحله تغییر می‌دهد.", points: ["Standard · حرکت مستقیم", "Scout · حرکت موجی سینوسی", "Shooter · شلیک زمان‌بندی‌شده", "Terrorist و Heavy Tank · تهدیدهای ویژه"], tag: "معماری شیءگرا و موج‌ها" },
      { eyebrow: "03 / THE GAME LOOP", title: "پشت هر فریم، یک زنجیره محاسبه است.", body: "در حلقه بازی، ورودی بازیکن، حرکت موجودات، شلیک‌ها، برخوردها، امتیاز و وضعیت موج با هم هماهنگ می‌شوند. برخورد هر گلوله می‌تواند جان دشمن را کم کند و شکست دشمن، امتیاز یا آیتم جدیدی به میدان برگرداند.", points: ["Game Loop با بازه ۲۰ میلی‌ثانیه", "بررسی برخورد و مدیریت جان", "امتیاز، سکه و ارتقای توانایی‌ها", "ذخیره اطلاعات بازیکن در SQLite"], tag: "قوانین، وضعیت و محاسبات" },
      { eyebrow: "04 / THE EXPERIENCE", title: "وقتی همه سیستم‌ها کنار هم می‌نشینند.", body: "منوی اصلی، ورود بازیکن، فروشگاه، تنظیمات صدا و میدان نبرد یک تجربه واحد می‌سازند. پیشرفت بازیکن ذخیره می‌شود و با هر موج، ترکیب و قدرت دشمن‌ها جدی‌تر می‌شود.", points: ["ورود و ذخیره اطلاعات بازیکن", "فروشگاه سفینه و ارتقای توانایی‌ها", "موسیقی پس‌زمینه و افکت‌های صوتی", "افزایش تدریجی سختی موج‌ها"], tag: "تجربه نهایی بازی" },
    ],
    labEyebrow: "05 / PLAYER LAB", labTitle: "حالا نوبت توست؛ قوانین میدان را تغییر بده.", labBody: "تنظیمات را تغییر بده، نتیجه را همان لحظه در بازی ببین و بعد توضیح بده چه تجربه‌ای می‌خواهی. تحلیل‌گر نمایشی، اثر تنظیمات و خواسته‌ات را روی سختی و بقا تخمین می‌زند.",
    settings: "تنظیمات آزمایش", preview: "میدان آزمایش زنده", model: "پیش‌بینی تحلیل‌گر", modelTag: "تحلیل محلی · بدون اتصال به سرویس AI", promptLabel: "چه تجربه‌ای می‌خواهی؟", promptPlaceholder: "مثلاً: یک نبرد سریع می‌خواهم که شلیک زیاد باشد و فرصت زنده ماندن هم داشته باشم...", predict: "تحلیل تنظیمات من", reset: "شروع دوباره بازی", music: "موسیقی پس‌زمینه", sfx: "افکت‌های صوتی", effects: "ذرات و انفجارها", difficulty: "ضریب سختی", speed: "سرعت سفینه", fireRate: "سرعت شلیک", health: "جان اولیه", musicVolume: "بلندی موسیقی", sfxVolume: "بلندی افکت‌ها", skin: "ظاهر سفینه", statScore: "امتیاز", statWave: "موج", statHealth: "جان", statCoins: "سکه", keys: "حرکت با WASD یا کلیدهای جهت‌دار · شلیک با Space", predictionWave: "موج تخمینی", predictionRisk: "ریسک برخورد", predictionSurvival: "شانس بقا", predictionNote: "این تخمین از روی تنظیمات فعلی و واژه‌های متن تو ساخته شده و نتیجه اجرای واقعی یا مدل هوش مصنوعی متصل نیست.",
    skins: ["کلاسیک", "قرمز", "صورتی", "سبز", "ویژه"],
    creatorEyebrow: "THE MAKER", creatorTitle: "ساخته‌شده با کنجکاوی، کدنویسی و کلی آزمون‌وخطا.", creatorBody: "من امیرحسین رضایی هستم. این بازی را در مسیر یادگیری C# از ابتدا تا انتها ساختم؛ از طراحی موجودیت‌ها و حلقه بازی تا رابط کاربری، صدا و ذخیره‌سازی اطلاعات.", contact: "راه‌های ارتباطی", github: "گیت‌هاب", resume: "رزومه", email: "ایمیل", telegram: "تلگرام", whatsapp: "واتساپ", eitaa: "ایتا", instagram: "اینستاگرام", source: "مشاهده کد پروژه", footer: "یک پروژه مستقل، با عشق به ساختن بازی‌ها.",
    modelEasy: "تنظیمات فعلی برای شروع آرام مناسب‌اند.", modelHard: "میدان پرتنش است؛ واکنش سریع و جاخالی دادن اهمیت زیادی دارد.", modelBalanced: "ترکیب فعلی تعادل مناسبی بین سرعت و فشار دشمن ایجاد می‌کند.",
  },
  en: {
    nav: ["Start", "Game world", "Game engine", "Game logic", "The result", "Playground"],
    heroEyebrow: "A personal project · Built with C#",
    heroTitle: "A simple idea. A universe ready for battle.",
    heroBody: "This is more than a space shooter walkthrough. Explore a game designed, programmed and brought to life from the ground up.",
    explore: "Explore the project", play: "Jump to the playground", scroll: "Scroll to continue",
    chapters: [
      { eyebrow: "01 / WORLD BUILDING", title: "First, we built the world.", body: "Before the first shot, we needed a world worth exploring. A cosmic backdrop, player ships, enemy fleets and power-ups come together to create a living battlefield.", points: ["Cosmic backdrop and custom HUD", "Five player ship skins", "Enemies, coins and power-ups"], tag: "Scene and asset design" },
      { eyebrow: "02 / GAME ARCHITECTURE", title: "Every enemy has its own behavior.", body: "This is more than a collection of animated images. Each enemy is an independent object with movement, health, score value and drop chance. The Wave Manager changes the fleet as the player progresses.", points: ["Standard · straight movement", "Scout · sine-wave movement", "Shooter · timed attacks", "Terrorist and Heavy Tank · special threats"], tag: "Object-oriented waves" },
      { eyebrow: "03 / THE GAME LOOP", title: "Every frame runs a chain of calculations.", body: "Player input, entity movement, projectiles, collisions, score and wave state are coordinated inside the game loop. A hit reduces enemy health; a defeated enemy can return points or a new item to the field.", points: ["20 ms game loop", "Collision and health management", "Score, coins and upgrades", "SQLite player persistence"], tag: "Rules, state and calculations" },
      { eyebrow: "04 / THE EXPERIENCE", title: "All systems become one experience.", body: "The main menu, player login, shop, audio settings and battlefield form one connected experience. Progress is saved, while each wave brings tougher enemy combinations.", points: ["Player login and saved progress", "Ship shop and upgrades", "Background music and sound effects", "Progressive wave difficulty"], tag: "The complete game" },
    ],
    labEyebrow: "05 / PLAYER LAB", labTitle: "Your turn. Change the rules of the battlefield.", labBody: "Tune the settings, watch the game react instantly, then describe the experience you want. The demo analyst estimates how your choices affect difficulty and survival.",
    settings: "Experiment settings", preview: "Live test arena", model: "Analyst prediction", modelTag: "Local analysis · No AI service connected", promptLabel: "What kind of run do you want?", promptPlaceholder: "For example: I want a fast battle with rapid fire and enough room to survive...", predict: "Analyze my setup", reset: "Restart game", music: "Background music", sfx: "Sound effects", effects: "Particles and explosions", difficulty: "Difficulty", speed: "Ship speed", fireRate: "Fire interval", health: "Starting health", musicVolume: "Music volume", sfxVolume: "Effects volume", skin: "Ship skin", statScore: "Score", statWave: "Wave", statHealth: "Health", statCoins: "Coins", keys: "Move with WASD or arrow keys · Shoot with Space", predictionWave: "Estimated wave", predictionRisk: "Collision risk", predictionSurvival: "Survival chance", predictionNote: "This estimate uses the current settings and words in your prompt. It is not a real gameplay result or a connected AI model.",
    skins: ["Classic", "Red", "Pink", "Green", "Special"],
    creatorEyebrow: "THE MAKER", creatorTitle: "Built with curiosity, code and a lot of trial and error.", creatorBody: "I'm Amirhossein Rezaaie. I built this game from the ground up while learning C#, from entities and the game loop to the UI, audio and persistence.", contact: "Get in touch", github: "GitHub", resume: "Resume", email: "Email", telegram: "Telegram", whatsapp: "WhatsApp", eitaa: "Eitaa", instagram: "Instagram", source: "Explore source code", footer: "An independent project, made with a love for building games.",
    modelEasy: "Your current setup is a good fit for a relaxed run.", modelHard: "The battlefield is intense. Fast reactions and dodging matter.", modelBalanced: "Your setup creates a balanced mix of speed and enemy pressure.",
  },
};

const enemyArt = ["enemy-standard.png", "enemy-scout.png", "enemy-shooter.png", "enemy-terrorist.png", "enemy-tank.png"];
const shipArt = ["player-default.png", "player-red.png", "player-pink.png", "player-green.png", "player-special.png"];

function ChapterScene({ index }: { index: number }) {
  if (index === 0) return (
    <div className="scene scene-world">
      <img className="scene-backdrop" src={asset("/game/background.png")} alt="" />
      <div className="scene-glow" />
      <span className="scene-chip chip-world">✦ WORLD ASSETS / 01</span>
      <img className="world-ship" src={asset("/game/player-default.png")} alt="Player spaceship" />
      <img className="world-enemy enemy-a" src={asset("/game/enemy-scout.png")} alt="Scout enemy" />
      <img className="world-enemy enemy-b" src={asset("/game/enemy-standard.png")} alt="Standard enemy" />
      <img className="world-enemy enemy-c" src={asset("/game/enemy-shooter.png")} alt="Shooter enemy" />
      <div className="world-orbit orbit-one" /><div className="world-orbit orbit-two" />
      <div className="scene-caption"><b>THE BATTLEFIELD</b><span>Player · Enemies · Environment</span></div>
      <div className="floating-token token-coin">◉ <small>COIN</small></div>
      <div className="floating-token token-health">✚ <small>HEALTH</small></div>
    </div>
  );
  if (index === 1) return (
    <div className="scene scene-waves">
      <img className="scene-backdrop" src={asset("/game/background.png")} alt="" />
      <span className="scene-chip">WAVE MANAGER / LIVE</span>
      <div className="wave-track"><span>WAVE 01</span><i /><i /><i /><i /><b>+2</b></div>
      {enemyArt.map((item, i) => <img key={item} className={`wave-enemy wave-enemy-${i}`} src={asset(`/game/${item}`)} alt="Enemy type" />)}
      <div className="wave-code"><span>SPAWN SEQUENCE</span><b>if (wave &lt;= 3)</b><b>  StandardEnemy()</b><b>  ScoutEnemy()</b><em>Next wave → stronger fleet</em></div>
      <div className="scene-caption"><b>5 ENEMY CLASSES</b><span>Different movement · health · score</span></div>
    </div>
  );
  if (index === 2) return (
    <div className="scene scene-logic">
      <img className="scene-backdrop" src={asset("/game/background.png")} alt="" />
      <span className="scene-chip">GAME LOOP / 20 MS</span>
      <div className="logic-orbit"><div className="logic-core">LOOP<span>50 FPS</span></div><i className="logic-node node-input">INPUT</i><i className="logic-node node-move">MOVE</i><i className="logic-node node-hit">COLLISION</i><i className="logic-node node-score">SCORE</i></div>
      <div className="logic-formula"><small>COLLISION CHECK</small><b>Bullet ∩ Enemy</b><span>Enemy.HP − 1</span><span>Score += Value</span><em>Drop chance → Power-up</em></div>
      <div className="scene-caption"><b>EVERY FRAME COUNTS</b><span>Input → Update → Detect → Render</span></div>
    </div>
  );
  return (
    <div className="scene scene-finale">
      <img className="scene-backdrop" src={asset("/game/gameplay.png")} alt="Screenshot of the original game in action" />
      <div className="finale-overlay"><span className="scene-chip">SYSTEMS ONLINE</span><div className="finale-stats"><b>250 <small>SCORE</small></b><b>05 <small>COINS</small></b><b>07 <small>WAVE</small></b></div><span className="finale-ready">✦ ALL SYSTEMS CONNECTED</span></div>
    </div>
  );
}

function RangeControl({ label, value, min, max, step = 1, onChange, suffix = "" }: { label: string; value: number; min: number; max: number; step?: number; onChange: (value: number) => void; suffix?: string }) {
  return <label className="range-control"><span>{label}<b>{value}{suffix}</b></span><input type="range" min={min} max={max} step={step} value={value} onChange={(event) => onChange(Number(event.target.value))} /></label>;
}

export default function Showcase() {
  const [locale, setLocale] = useState<Locale>("fa");
  const [theme, setTheme] = useState<Theme>("dark");
  const [active, setActive] = useState(0);
  const [settings, setSettings] = useState<GameConfig>({ ship: shipArt[0], speed: 7, fireRate: 0.2, difficulty: 1, health: 3, effects: true, sfx: false, sfxVolume: 65, music: false, musicVolume: 24 });
  const [stats, setStats] = useState<Stats>({ score: 0, wave: 1, health: 3, coins: 0 });
  const [prompt, setPrompt] = useState("");
  const [predicted, setPredicted] = useState(false);
  const [restartKey, setRestartKey] = useState(0);
  const t = copy[locale];
  const isFa = locale === "fa";

  const updateSetting = <K extends keyof GameConfig>(key: K, value: GameConfig[K]) => setSettings((previous) => ({ ...previous, [key]: value }));
  const onStats = useCallback((next: Stats) => setStats(next), []);

  useEffect(() => {
    document.documentElement.lang = locale;
    document.documentElement.dir = isFa ? "rtl" : "ltr";
  }, [locale, isFa]);

  useEffect(() => {
    const sections = Array.from(document.querySelectorAll<HTMLElement>("[data-chapter]"));
    const observer = new IntersectionObserver((entries) => {
      entries.forEach((entry) => {
        if (entry.isIntersecting) setActive(Number(entry.target.getAttribute("data-chapter")));
      });
    }, { threshold: 0.42, rootMargin: "-12% 0px -20% 0px" });
    sections.forEach((section) => observer.observe(section));
    return () => observer.disconnect();
  }, []);

  const prediction = useMemo(() => {
    const text = prompt.toLowerCase();
    const defensive = /آرام|دفاع|زنده|بقا|easy|calm|surviv|defen/.test(text);
    const aggressive = /سریع|تهاجم|زیاد|سخت|چالش|fast|rapid|aggress|hard|challeng/.test(text);
    const risk = Math.max(5, Math.min(95, Math.round(26 + settings.difficulty * 23 - settings.speed * 2.1 - (1 / settings.fireRate) * 1.8 + (aggressive ? 8 : 0) - (defensive ? 12 : 0) + (settings.health < 3 ? 12 : 0))));
    const wave = Math.max(1, Math.round(3 + settings.speed * 0.52 + (1 / settings.fireRate) * 0.55 + settings.health * 0.48 - settings.difficulty * 1.7 + (defensive ? 0.5 : 0) + (aggressive ? 1 : 0)));
    return { risk, wave, survival: 100 - risk, mood: risk > 58 ? t.modelHard : risk < 28 ? t.modelEasy : t.modelBalanced };
  }, [prompt, settings.difficulty, settings.speed, settings.fireRate, settings.health, t]);

  const scrollTo = (id: string) => document.getElementById(id)?.scrollIntoView({ behavior: "smooth" });
  const chapterIds = ["intro", "world", "architecture", "logic", "result", "lab"];

  return (
    <div className={`site-shell ${theme}`}>
      <div className="ambient ambient-one" /><div className="ambient ambient-two" />
      <header className="topbar">
        <a className="brand" href="#intro" aria-label="Space Shooter home"><span className="brand-mark">✦</span><span>SPACE<span className="brand-muted">SHOOTER</span></span></a>
        <nav className="top-nav" aria-label="Main navigation">{t.nav.map((label, index) => <button key={label} className={active === index ? "active" : ""} onClick={() => scrollTo(chapterIds[index])}>{label}</button>)}</nav>
        <div className="top-actions"><button className="language-switch" onClick={() => setLocale(isFa ? "en" : "fa")} aria-label="Switch language">{isFa ? "EN" : "FA"}<span>↗</span></button><button className="theme-switch" onClick={() => setTheme(theme === "dark" ? "light" : "dark")} aria-label="Toggle theme">{theme === "dark" ? "☼" : "☾"}</button></div>
      </header>
      <div className="reading-progress"><span style={{ width: `${((active + 1) / 6) * 100}%` }} /></div>

      <main>
        <section className="hero section-wrap" id="intro" data-chapter="0">
          <div className="hero-copy">
            <span className="eyebrow"><i />{t.heroEyebrow}</span>
            <h1>{t.heroTitle}</h1>
            <p>{t.heroBody}</p>
            <div className="hero-actions"><button className="button-primary" onClick={() => scrollTo("world")}>{t.explore}<span>↗</span></button><button className="button-quiet" onClick={() => scrollTo("lab")}>{t.play}<span>⌄</span></button></div>
            <div className="hero-meta"><span><b>01</b> C# / .NET 10</span><span><b>02</b> Windows Forms</span><span><b>03</b> Object Oriented</span></div>
          </div>
          <div className="hero-art">
            <div className="hero-grid" /><div className="hero-ring ring-large" /><div className="hero-ring ring-small" />
            <img className="hero-ship" src={asset("/game/player-default.png")} alt="Space Shooter player ship" />
            <img className="hero-foe foe-one" src={asset("/game/enemy-shooter.png")} alt="Enemy ship" /><img className="hero-foe foe-two" src={asset("/game/enemy-scout.png")} alt="Scout ship" />
            <div className="hero-coordinate">37° 14′ 08″ N<br />MISSION / 001</div><div className="hero-orbit-label">READY FOR LAUNCH <span>●</span></div>
            <div className="hero-scroll" onClick={() => scrollTo("world")} role="button" tabIndex={0}>{t.scroll}<span>↓</span></div>
          </div>
        </section>

        {t.chapters.map((chapter, index) => (
          <section className={`chapter-section section-wrap chapter-${index + 1}`} id={chapterIds[index + 1]} data-chapter={index + 1} key={chapter.eyebrow}>
            <div className="chapter-grid">
              <div className="chapter-copy">
                <span className="eyebrow"><i />{chapter.eyebrow}</span>
                <span className="chapter-number">0{index + 1}<b> / 04</b></span>
                <h2>{chapter.title}</h2><p>{chapter.body}</p>
                <ul className="chapter-points">{chapter.points.map((point) => <li key={point}><span>✳</span>{point}</li>)}</ul>
                <span className="chapter-tag">{chapter.tag}<b>↗</b></span>
              </div>
              <div className={`chapter-stage stage-${index + 1}`}><ChapterScene index={index} /><span className="stage-index">FIG. 0{index + 1} <i> / SPACE SHOOTER</i></span></div>
            </div>
            <div className="chapter-connector"><span>SCROLL TO NEXT SEQUENCE</span><i>↓</i></div>
          </section>
        ))}

        <section className="lab-section section-wrap" id="lab" data-chapter="5">
          <div className="lab-heading"><div><span className="eyebrow"><i />{t.labEyebrow}</span><h2>{t.labTitle}</h2></div><p>{t.labBody}</p></div>
          <div className="lab-layout">
            <aside className="settings-panel">
              <div className="panel-heading"><span className="panel-icon">⌘</span><div><b>{t.settings}</b><small>LIVE CONFIGURATION</small></div><span className="live-dot">● LIVE</span></div>
              <div className="setting-toggles">
                <label><span>♫ {t.music}</span><input type="checkbox" checked={settings.music} onChange={(e) => updateSetting("music", e.target.checked)} /><i /></label>
                <label><span>◖ {t.sfx}</span><input type="checkbox" checked={settings.sfx} onChange={(e) => updateSetting("sfx", e.target.checked)} /><i /></label>
                <label><span>✧ {t.effects}</span><input type="checkbox" checked={settings.effects} onChange={(e) => updateSetting("effects", e.target.checked)} /><i /></label>
              </div>
              <div className="setting-group"><div className="setting-group-title">GAMEPLAY <span>01</span></div>
                <RangeControl label={t.difficulty} value={settings.difficulty} min={0.5} max={2} step={0.1} suffix="×" onChange={(value) => updateSetting("difficulty", value)} />
                <RangeControl label={t.speed} value={settings.speed} min={3} max={10} suffix=" px" onChange={(value) => updateSetting("speed", value)} />
                <RangeControl label={t.fireRate} value={settings.fireRate} min={0.15} max={0.8} step={0.05} suffix=" s" onChange={(value) => updateSetting("fireRate", value)} />
                <RangeControl label={t.health} value={settings.health} min={1} max={5} suffix=" ♥" onChange={(value) => updateSetting("health", value)} />
              </div>
              <div className="setting-group"><div className="setting-group-title">AUDIO <span>02</span></div>
                <RangeControl label={t.musicVolume} value={settings.musicVolume} min={0} max={100} suffix="%" onChange={(value) => updateSetting("musicVolume", value)} />
                <RangeControl label={t.sfxVolume} value={settings.sfxVolume} min={0} max={100} suffix="%" onChange={(value) => updateSetting("sfxVolume", value)} />
              </div>
              <div className="setting-group"><div className="setting-group-title">SHIP SELECT <span>03</span></div><div className="skin-picker">{shipArt.map((ship, index) => <button key={ship} className={settings.ship === ship ? "selected" : ""} onClick={() => updateSetting("ship", ship)} aria-label={t.skins[index]} title={t.skins[index]}><img src={asset(`/game/${ship}`)} alt="" /></button>)}</div></div>
              <div className="settings-footnote">↳ {isFa ? "تغییرات به‌صورت زنده روی میدان اعمال می‌شوند." : "Changes are applied to the arena in real time."}</div>
            </aside>

            <div className="lab-main">
              <div className="game-panel">
                <div className="game-panel-top"><div><span className="live-dot">● LIVE SESSION</span><b>{t.preview}</b></div><button className="restart-button" onClick={() => setRestartKey((value) => value + 1)}>↻ {t.reset}</button></div>
                <div className="game-frame"><GameCanvas config={settings} active={true} restartKey={restartKey} onStats={onStats} /></div>
                <div className="game-stats">{[[t.statScore, stats.score.toString().padStart(4, "0")], [t.statWave, stats.wave.toString().padStart(2, "0")], [t.statHealth, stats.health.toString()], [t.statCoins, stats.coins.toString().padStart(2, "0")]].map(([label, value]) => <div key={label}><small>{label}</small><b>{value}</b></div>)}</div>
                <div className="game-controls"><span>⌨ {t.keys}</span><div>{(["arrowleft", "arrowup", "arrowdown", "arrowright"] as const).map((key, index) => <button key={key} onPointerDown={() => window.dispatchEvent(new KeyboardEvent("keydown", { key }))} onPointerUp={() => window.dispatchEvent(new KeyboardEvent("keyup", { key }))} onPointerLeave={() => window.dispatchEvent(new KeyboardEvent("keyup", { key }))}>{["←", "↑", "↓", "→"][index]}</button>)}</div></div>
              </div>

              <div className="prediction-panel">
                <div className="prediction-title"><span className="prediction-icon">⌁</span><div><b>{t.model}</b><small>{t.modelTag}</small></div><span className="prediction-spark">✳</span></div>
                <label className="prompt-field"><span>{t.promptLabel}</span><textarea value={prompt} onChange={(event) => { setPrompt(event.target.value); setPredicted(false); }} placeholder={t.promptPlaceholder} rows={3} /></label>
                <button className="predict-button" onClick={() => setPredicted(true)}>{t.predict}<span>✦</span></button>
                <div className={`prediction-results ${predicted ? "revealed" : ""}`}>
                  <div className="prediction-metrics"><div><small>{t.predictionWave}</small><b>{prediction.wave}<em>+</em></b></div><div><small>{t.predictionRisk}</small><b>{prediction.risk}<em>%</em></b></div><div><small>{t.predictionSurvival}</small><b>{prediction.survival}<em>%</em></b></div></div>
                  <p>{prediction.mood}</p>
                </div>
                <small className="prediction-disclaimer">ⓘ {t.predictionNote}</small>
              </div>
            </div>
          </div>
        </section>

        <section className="creator-section section-wrap" id="creator">
          <div className="creator-card"><div className="creator-avatar"><span>AR</span><i>✦</i></div><div className="creator-copy"><span className="eyebrow"><i />{t.creatorEyebrow}</span><h2>{t.creatorTitle}</h2><p>{t.creatorBody}</p><div className="creator-actions"><a href="https://github.com/AmirHosseinRezaaie" target="_blank" rel="noreferrer">◈ {t.github}</a><a href="https://amirhosseinrezaaie.github.io/CW_project_Resume-Web-Page/" target="_blank" rel="noreferrer">↗ {t.resume}</a><a href="mailto:ah.rezaaie@gmail.com">✉ {t.email}</a></div></div><div className="contact-links"><b>{t.contact}</b><a href="https://t.me/amirhossein122333" target="_blank" rel="noreferrer">↗ {t.telegram}</a><a href="https://wa.me/qr/DXZSKFSOLGCMH1" target="_blank" rel="noreferrer">↗ {t.whatsapp}</a><a href="https://eitaa.com/amirhossein122333" target="_blank" rel="noreferrer">↗ {t.eitaa}</a><a href="https://instagram.com/amir_hosein122333" target="_blank" rel="noreferrer">↗ {t.instagram}</a></div></div>
          <footer className="site-footer"><a className="brand" href="#intro"><span className="brand-mark">✦</span><span>SPACE<span className="brand-muted">SHOOTER</span></span></a><span>{t.footer}</span><a href="https://github.com/AmirHosseinRezaaie/SpaceShooter-Game" target="_blank" rel="noreferrer">{t.source} ↗</a><span>© 2026</span></footer>
        </section>
      </main>
    </div>
  );
}
