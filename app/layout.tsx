import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "SPACE SHOOTER — از ایده تا مدار نبرد",
  description:
    "روایت تعاملی ساخت یک بازی سفینه‌ای با C# و Windows Forms؛ از طراحی جهان و دشمن‌ها تا منطق بازی و تجربه قابل شخصی‌سازی.",
  applicationName: "Space Shooter Showcase",
  openGraph: {
    title: "SPACE SHOOTER — از ایده تا مدار نبرد",
    description: "یک سفر تعاملی درون معماری، منطق و تجربه بازی Space Shooter.",
    type: "website",
  },
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  const basePath = process.env.NEXT_PUBLIC_BASE_PATH ?? "";
  return (
    <html lang="fa" dir="rtl" suppressHydrationWarning>
      <body>
        <style>{`@font-face{font-family:Vazirmatn;src:url('${basePath}/fonts/vazirmatn-variable.woff2') format('woff2');font-weight:100 900;font-display:swap}`}</style>
        {children}
      </body>
    </html>
  );
}
