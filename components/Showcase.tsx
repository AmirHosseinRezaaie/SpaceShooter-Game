"use client";

import { useCallback, useEffect, useState } from "react";
import GameCanvas, { type GameConfig } from "@/components/GameCanvas";

const BASE = process.env.NEXT_PUBLIC_BASE_PATH ?? "";
const asset = (path: string) => `${BASE}${path}`;

type Locale = "fa" | "en";
type Theme = "dark" | "light";
type Stats = { score: number; wave: number; health: number; coins: number };

const copy = {
  fa: {
    nav: ["شروع سفر", "جهان بازی", "طراحی دشمن‌ها", "منطق بازی", "سیستم‌ها", "آزمایشگاه", "سازنده"],
    heroEyebrow: "یک پروژه شخصی · ساخته‌شده با C#",
    heroTitle: "از یک ایده ساده، تا یک جهان در حال نبرد.",
    heroBody: "این‌جا فقط یک بازی سفینه‌ای را تماشا نمی‌کنی؛ قدم‌به‌قدم وارد دنیایی می‌شوی که از صفر طراحی، برنامه‌نویسی و زنده شده است.",
    explore: "شروع سفر در پروژه", play: "رفتن به آزمایشگاه", scroll: "برای ادامه اسکرول کن",
    chapters: [
      { eyebrow: "01 / WORLD BUILDING", title: "جهان بازی را از اجزای مستقل ساختیم.", body: "ساخت بازی را با تعریف قاب تجربه شروع کردیم: پس‌زمینه‌ای که عمق میدان را منتقل کند، سفینه‌ای که همیشه خوانا بماند، HUD برای نمایش وضعیت و آیتم‌هایی که تصمیم بازیکن را عوض می‌کنند. هر دارایی برای نقشی مشخص انتخاب و در صحنه جای‌گذاری شد.", points: ["پس‌زمینه چندلایه و HUD اختصاصی", "۵ پوسته قابل انتخاب برای بازیکن", "سکه، جان، سپر و شلیک سه‌تایی", "تفکیک فایل‌های تصویری و صوتی منابع"], tag: "ترکیب صحنه و دارایی‌ها" },
      { eyebrow: "02 / ENEMY DESIGN", title: "برای هر دشمن، یک نقش و قانون تعریف کردیم.", body: "روی هر سفینه کلیک کن تا مشخصات و تصمیم طراحی آن را ببینی. تفاوت دشمن‌ها فقط ظاهر نیست: الگوی حرکت، جان، سرعت، امتیاز، نوع حمله و احتمال پاداش تعیین می‌کند بازیکن با چه تهدیدی روبه‌رو است.", points: ["۵ کلاس دشمن با نقش متفاوت", "حرکت مستقیم، موجی و تعقیب بازیکن", "شلیک دشمنان دوربرد و تانک", "جان و پاداش متناسب با سطح تهدید"], tag: "رفتارهای مستقل دشمنان" },
      { eyebrow: "03 / GAME LOOP", title: "هر فریم، جهان بازی را یک قدم جلو می‌برد.", body: "حلقه اصلی ورودی‌ها را می‌خواند، موقعیت سفینه‌ها را به‌روزرسانی می‌کند، گلوله‌ها و برخوردها را بررسی می‌کند و در پایان صحنه را رسم می‌کند. زمان‌بندی ثابت کمک می‌کند حرکت و شلیک قابل پیش‌بینی و هماهنگ بمانند.", points: ["به‌روزرسانی بازی در بازه ۲۰ میلی‌ثانیه", "حرکت با صفحه‌کلید و محدودیت محدوده", "تولید موج و افزایش تدریجی فشار", "رسم فریم و به‌روزرسانی HUD"], tag: "چرخه اجرای بازی" },
      { eyebrow: "04 / GAME RULES", title: "برخوردها، جان و پاداش‌ها یک زنجیره‌اند.", body: "برخورد گلوله با دشمن ابتدا جان را کم می‌کند؛ با رسیدن جان به صفر، دشمن حذف می‌شود، امتیاز متناسب ثبت می‌شود و ممکن است سکه یا Power-up رها کند. برخورد بازیکن با دشمن یا گلوله هم جان را کم می‌کند، مگر سپر فعال باشد.", points: ["بررسی محدوده برخورد گلوله و دشمن", "محاسبه جان و امتیاز بر اساس کلاس", "احتمال افتادن سکه و آیتم کمکی", "سپر موقت و شلیک سه‌تایی زمان‌دار"], tag: "قوانین و محاسبات گیم‌پلی" },
      { eyebrow: "05 / COMPLETE EXPERIENCE", title: "سیستم‌ها به یک بازی کامل متصل شدند.", body: "منوی اصلی، ورود بازیکن، فروشگاه، تنظیمات، موسیقی و میدان نبرد بخش‌های یک تجربه پیوسته‌اند. اطلاعات بازیکن در SQLite ذخیره می‌شود و سیستم موج، با پیشرفت بازی ترکیب دشمن‌ها و شدت نبرد را تغییر می‌دهد.", points: ["ورود و نگهداری اطلاعات بازیکن", "فروشگاه سفینه و ارتقای توانایی‌ها", "موسیقی و افکت‌های قابل تنظیم", "موج‌های پویا و ذخیره پیشرفت"], tag: "اتصال سیستم‌ها و تجربه نهایی" },
    ],
    labEyebrow: "06 / PLAYER LAB", labTitle: "حالا نوبت توست؛ قوانین میدان را تغییر بده.", labBody: "سفینه، سرعت، جان، سختی، موسیقی و افکت‌ها را تغییر بده و اثر هر انتخاب را همان لحظه در نسخه قابل‌بازی ببین. با صفحه‌کلید یا کنترل‌های لمسی سفینه را هدایت کن.",
    settings: "تنظیمات آزمایش", preview: "میدان آزمایش زنده", reset: "شروع دوباره بازی", music: "موسیقی پس‌زمینه", sfx: "افکت‌های صوتی", effects: "ذرات و انفجارها", difficulty: "ضریب سختی", speed: "سرعت سفینه", fireRate: "سرعت شلیک", health: "جان اولیه", musicVolume: "بلندی موسیقی", sfxVolume: "بلندی افکت‌ها", skin: "ظاهر سفینه", statScore: "امتیاز", statWave: "موج", statHealth: "جان", statCoins: "سکه", keys: "حرکت با WASD یا کلیدهای جهت‌دار · شلیک با Space",
    skins: ["کلاسیک", "قرمز", "صورتی", "سبز", "ویژه"],
    creatorEyebrow: "THE MAKER", creatorTitle: "ساخته‌شده با کنجکاوی، کدنویسی و کلی آزمون‌وخطا.", creatorBody: "من امیرحسین رضایی هستم. این بازی را در مسیر یادگیری C# از ابتدا تا انتها ساختم؛ از طراحی موجودیت‌ها و حلقه بازی تا رابط کاربری، صدا و ذخیره‌سازی اطلاعات.", contact: "راه‌های ارتباطی", github: "گیت‌هاب", resume: "رزومه", email: "ایمیل", telegram: "تلگرام", whatsapp: "واتساپ", eitaa: "ایتا", instagram: "اینستاگرام", source: "مشاهده کد پروژه", footer: "یک پروژه مستقل، با عشق به ساختن بازی‌ها.",
  },
  en: {
    nav: ["Start", "World", "Enemy design", "Game loop", "Game rules", "Playground", "Creator"],
    heroEyebrow: "A personal project · Built with C#",
    heroTitle: "A simple idea. A universe ready for battle.",
    heroBody: "This is more than a space shooter walkthrough. Explore a game designed, programmed and brought to life from the ground up.",
    explore: "Explore the project", play: "Jump to the playground", scroll: "Scroll to continue",
    chapters: [
      { eyebrow: "01 / WORLD BUILDING", title: "We built the world from independent pieces.", body: "We began by defining the experience: a backdrop with depth, a readable player ship, a HUD for status and pickups that change player decisions. Every asset has a clear role in the battlefield.", points: ["Layered space backdrop and custom HUD", "Five selectable player skins", "Coins, health, shield and triple shot", "Separate image and audio resources"], tag: "Scene and asset composition" },
      { eyebrow: "02 / ENEMY DESIGN", title: "Every enemy has a role and a rule.", body: "Select an enemy to inspect its behavior and design decisions. Their differences go beyond appearance: movement, health, speed, score, attack and drop chance define each threat.", points: ["Five enemy classes", "Straight, wave and pursuit movement", "Ranged attacks and heavy tank", "Health and rewards scale with threat"], tag: "Independent enemy behavior" },
      { eyebrow: "03 / GAME LOOP", title: "Every frame moves the world forward.", body: "The main loop reads input, updates ship positions, advances projectiles, checks collisions and renders the scene. A fixed interval keeps movement and firing coordinated.", points: ["20 ms update interval", "Keyboard movement and arena bounds", "Wave spawning and rising pressure", "Frame rendering and HUD updates"], tag: "The game execution cycle" },
      { eyebrow: "04 / GAME RULES", title: "Collisions, health and rewards form one chain.", body: "A projectile hit reduces enemy health. At zero health, the enemy is removed, its score is awarded and it may drop a coin or power-up. Enemy contact and projectiles damage the player unless a shield is active.", points: ["Projectile and enemy hit checks", "Class-based health and score", "Coin and power-up drop chances", "Timed shield and triple shot"], tag: "Gameplay rules and calculations" },
      { eyebrow: "05 / COMPLETE EXPERIENCE", title: "All systems connect into one game.", body: "The main menu, player login, shop, settings, music and battlefield form one continuous experience. SQLite stores player data while waves introduce tougher enemy combinations.", points: ["Player login and persistence", "Ship shop and upgrades", "Configurable music and sound effects", "Dynamic waves and saved progress"], tag: "The complete experience" },
    ],
    labEyebrow: "06 / PLAYER LAB", labTitle: "Your turn. Change the rules of the battlefield.", labBody: "Change the ship, speed, health, difficulty, music and effects, then see every choice reflected instantly in the playable build. Pilot with your keyboard or touch controls.",
    settings: "Experiment settings", preview: "Live test arena", reset: "Restart game", music: "Background music", sfx: "Sound effects", effects: "Particles and explosions", difficulty: "Difficulty", speed: "Ship speed", fireRate: "Fire interval", health: "Starting health", musicVolume: "Music volume", sfxVolume: "Effects volume", skin: "Ship skin", statScore: "Score", statWave: "Wave", statHealth: "Health", statCoins: "Coins", keys: "Move with WASD or arrow keys · Shoot with Space",
    skins: ["Classic", "Red", "Pink", "Green", "Special"],
    creatorEyebrow: "THE MAKER", creatorTitle: "Built with curiosity, code and a lot of trial and error.", creatorBody: "I'm Amirhossein Rezaaie. I built this game from the ground up while learning C#, from entities and the game loop to the UI, audio and persistence.", contact: "Get in touch", github: "GitHub", resume: "Resume", email: "Email", telegram: "Telegram", whatsapp: "WhatsApp", eitaa: "Eitaa", instagram: "Instagram", source: "Explore source code", footer: "An independent project, made with a love for building games.",
  },
};

const enemyArt = ["enemy-standard.png", "enemy-scout.png", "enemy-shooter.png", "enemy-terrorist.png", "enemy-tank.png"];
const shipArt = ["player-default.png", "player-red.png", "player-pink.png", "player-green.png", "player-special.png"];
const enemySpecs = {
  fa: [
    { name: "دشمن استاندارد", role: "تهدید پایه · فشار پیوسته", behavior: "در مسیر مستقیم به سمت پایین حرکت می‌کند و الگوی اصلی سنجش مهارت بازیکن است.", stats: "جان ۲ · سرعت ۲ · امتیاز ۱۰", logic: "با برخورد گلوله جانش کم می‌شود؛ پس از نابودی، شانس ۲۰٪ برای سکه دارد." },
    { name: "جنگنده Scout", role: "هدف چابک · حرکت غیرخطی", behavior: "علاوه بر حرکت رو به پایین، با تابع سینوسی به چپ و راست منحرف می‌شود.", stats: "جان ۲ · سرعت ۳ · امتیاز ۲۰", logic: "سرعت بیشتر و مسیر موجی، زمان‌بندی شلیک را دشوارتر می‌کند؛ شانس سکه ۳۰٪ است." },
    { name: "ناوشکن Shooter", role: "حمله از فاصله دور", behavior: "در میدان پیشروی می‌کند و با فاصله زمانی مشخص به سمت بازیکن گلوله شلیک می‌کند.", stats: "جان ۴ · سرعت ۲ · امتیاز ۳۰", logic: "فاصله شلیک با سختی موج تنظیم می‌شود؛ شانس سکه ۴۰٪ است." },
    { name: "تعقیب‌گر Terrorist", role: "تهدید تعقیب‌کننده", behavior: "فاصله تا مرکز سفینه بازیکن را محاسبه می‌کند و در راستای آن حرکت می‌کند تا به هدف نزدیک شود.", stats: "جان ۱۱ · سرعت ۲ · امتیاز ۸۰", logic: "بردار اختلاف موقعیت به فاصله اقلیدسی تقسیم می‌شود تا حرکت جهت‌دار و نرمال داشته باشد؛ شانس سکه ۶۰٪ است." },
    { name: "تانک سنگین", role: "مینی‌باس · دوام و آتش", behavior: "بدنه بزرگ و جان زیاد دارد و با فاصله زمانی کوتاه‌تر، گلوله‌های سنگین شلیک می‌کند.", stats: "جان ۱۶ · سرعت ۱ · امتیاز ۱۰۰", logic: "فشار اصلی از دوام و شلیک‌های پی‌درپی می‌آید؛ شانس سکه ۸۰٪ است." },
  ],
  en: [
    { name: "Standard enemy", role: "Baseline threat · steady pressure", behavior: "Moves straight down the arena and establishes the baseline challenge for the player.", stats: "HP 2 · Speed 2 · Score 10", logic: "Each hit reduces health; a defeated unit has a 20% coin drop chance." },
    { name: "Scout fighter", role: "Agile target · nonlinear movement", behavior: "Moves downward while drifting left and right along a sine-wave path.", stats: "HP 2 · Speed 3 · Score 20", logic: "Higher speed and wave movement make shot timing harder; coin chance is 30%." },
    { name: "Shooter destroyer", role: "Ranged pressure", behavior: "Advances through the arena and fires projectiles at timed intervals.", stats: "HP 4 · Speed 2 · Score 30", logic: "Its firing interval scales with difficulty; coin chance is 40%." },
    { name: "Terrorist pursuer", role: "Homing threat", behavior: "Calculates the distance to the player ship and moves along that direction to close the gap.", stats: "HP 11 · Speed 2 · Score 80", logic: "The position delta is normalized by Euclidean distance to create directional pursuit; coin chance is 60%." },
    { name: "Heavy tank", role: "Mini-boss · durability and fire", behavior: "Has a large hitbox and high health, then launches heavy projectiles at timed intervals.", stats: "HP 16 · Speed 1 · Score 100", logic: "Its threat comes from durability and repeated fire; coin chance is 80%." },
  ],
};

function ChapterScene({ index, selectedEnemy, onSelectEnemy }: { index: number; selectedEnemy: number; onSelectEnemy: (index: number) => void }) {
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
      {enemyArt.map((item, i) => <button type="button" key={item} className={`wave-enemy-button wave-enemy-${i} ${selectedEnemy === i ? "chosen" : ""}`} onClick={() => onSelectEnemy(i)} aria-label={`Select ${enemySpecs.en[i].name}`} aria-pressed={selectedEnemy === i}><img src={asset(`/game/${item}`)} alt="" /><span>{["01", "02", "03", "04", "05"][i]}</span></button>)}
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
  const [selectedEnemy, setSelectedEnemy] = useState(0);
  const [typedEnemy, setTypedEnemy] = useState("");
  const [restartKey, setRestartKey] = useState(0);
  const t = copy[locale];
  const isFa = locale === "fa";

  const updateSetting = <K extends keyof GameConfig>(key: K, value: GameConfig[K]) => setSettings((previous) => ({ ...previous, [key]: value }));
  const onStats = useCallback((next: Stats) => setStats(next), []);
  const selectedSpec = enemySpecs[locale][selectedEnemy];

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

  useEffect(() => {
    const fullText = `${selectedSpec.role}\n\n${selectedSpec.behavior}\n\n${selectedSpec.stats}\n\n${selectedSpec.logic}`;
    setTypedEnemy("");
    let position = 0;
    const timer = window.setInterval(() => {
      position += 1;
      setTypedEnemy(fullText.slice(0, position));
      if (position >= fullText.length) window.clearInterval(timer);
    }, 19);
    return () => window.clearInterval(timer);
  }, [selectedSpec]);

  const scrollTo = (id: string) => document.getElementById(id)?.scrollIntoView({ behavior: "smooth" });
  const chapterIds = ["intro", "world", "architecture", "logic", "result", "lab", "creator"];

  return (
    <div className={`site-shell ${theme}`}>
        <div className="ambient ambient-one" /><div className="ambient ambient-two" />
      <header className="topbar">
        <a className="brand" href="#intro" aria-label="Space Shooter home"><span className="brand-mark">✦</span><span>SPACE<span className="brand-muted">SHOOTER</span></span></a>
        <nav className="top-nav" aria-label="Main navigation">{t.nav.map((label, index) => <button key={label} className={active === index ? "active" : ""} onClick={() => scrollTo(chapterIds[index])}>{label}</button>)}</nav>
        <div className="top-actions"><button className="language-switch" onClick={() => setLocale(isFa ? "en" : "fa")} aria-label="Switch language"><span className="control-orbit">◎</span><span>{isFa ? "EN" : "FA"}</span><small>{isFa ? "English" : "فارسی"}</small></button><button className="theme-switch" onClick={() => setTheme(theme === "dark" ? "light" : "dark")} aria-label="Toggle theme"><span>{theme === "dark" ? "☼" : "☾"}</span><small>{theme === "dark" ? (isFa ? "روز" : "Light") : (isFa ? "شب" : "Dark")}</small></button></div>
      </header>
      <div className="reading-progress"><span style={{ width: `${((active + 1) / 7) * 100}%` }} /></div>

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
                <span className="chapter-number">0{index + 1}<b> / 05</b></span>
                <h2>{chapter.title}</h2><p>{chapter.body}</p>
                <ul className="chapter-points">{chapter.points.map((point) => <li key={point}><span>✳</span>{point}</li>)}</ul>
                {index === 1 && <div className="enemy-inspector" aria-live="polite"><div className="inspector-head"><span>◈ {isFa ? "پرونده دشمن انتخاب‌شده" : "SELECTED ENEMY DOSSIER"}</span><b>0{selectedEnemy + 1} / 05</b></div><h3>{selectedSpec.name}</h3><p className="typed-spec">{typedEnemy}<i className="typing-caret" /></p></div>}
                <span className="chapter-tag">{chapter.tag}<b>↗</b></span>
              </div>
              <div className={`chapter-stage stage-${index + 1}`}>{index === 1 && <p className="scene-hint">{isFa ? "برای بررسی، روی هر سفینه کلیک کن" : "CLICK ANY SHIP TO INSPECT IT"}</p>}<ChapterScene index={index} selectedEnemy={selectedEnemy} onSelectEnemy={setSelectedEnemy} /><span className="stage-index">FIG. 0{index + 1} <i> / SPACE SHOOTER</i></span></div>
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

            </div>
          </div>
        </section>

        <section className="creator-section section-wrap" id="creator" data-chapter="6">
          <div className="creator-card"><div className="creator-avatar"><img src="https://github.com/AmirHosseinRezaaie.png" alt="Amirhossein Rezaaie" /><i>✦</i></div><div className="creator-copy"><span className="eyebrow"><i />{t.creatorEyebrow}</span><h2>{t.creatorTitle}</h2><p>{t.creatorBody}</p><div className="creator-actions"><a href="https://github.com/AmirHosseinRezaaie" target="_blank" rel="noreferrer"><span>⌘</span>{t.github}</a><a href="https://amirhosseinrezaaie.github.io/CW_project_Resume-Web-Page/" target="_blank" rel="noreferrer"><span>▤</span>{t.resume}</a><a href="mailto:ah.rezaaie@gmail.com"><span>✉</span>{t.email}</a></div></div><div className="contact-links"><b>{t.contact}</b><a href="https://t.me/amirhossein122333" target="_blank" rel="noreferrer"><span>➤</span>{t.telegram}</a><a href="https://wa.me/qr/DXZSKFSOLGCMH1" target="_blank" rel="noreferrer"><span>◉</span>{t.whatsapp}</a><a href="https://eitaa.com/amirhossein122333" target="_blank" rel="noreferrer"><span>✳</span>{t.eitaa}</a><a href="https://instagram.com/amir_hosein122333" target="_blank" rel="noreferrer"><span>◎</span>{t.instagram}</a></div></div>
          <footer className="site-footer"><a className="brand" href="#intro"><span className="brand-mark">✦</span><span>SPACE<span className="brand-muted">SHOOTER</span></span></a><span>{t.footer}</span><a href="https://github.com/AmirHosseinRezaaie/SpaceShooter-Game" target="_blank" rel="noreferrer">{t.source} ↗</a><span>© 2026</span></footer>
        </section>
      </main>
    </div>
  );
}
