import type { Metadata } from "next";
import "./globals.css";

const basePath = process.env.NEXT_PUBLIC_BASE_PATH ?? "";

export const metadata: Metadata = {
  title: "SPACE SHOOTER | از ایده تا میدان نبرد",
  description:
    "روایت تعاملی ساخت یک بازی سفینه‌ای با C# و Windows Forms؛ از طراحی جهان و دشمن‌ها تا منطق بازی و تجربه قابل شخصی‌سازی.",
  applicationName: "Space Shooter Showcase",
  icons: {
    icon: [{ url: `${basePath}/icon.svg`, type: "image/svg+xml" }],
    shortcut: `${basePath}/icon.svg`,
    apple: `${basePath}/icon.svg`,
  },
  openGraph: {
    title: "SPACE SHOOTER | از ایده تا میدان نبرد",
    description: "یک سفر تعاملی درون معماری، منطق و تجربه بازی Space Shooter.",
    type: "website",
  },
  twitter: {
    card: "summary_large_image",
    title: "SPACE SHOOTER | از ایده تا میدان نبرد",
    description: "یک بازی سفینه‌ای؛ از کدنویسی تا تجربه قابل بازی.",
  },
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  return (
    <html lang="fa" dir="rtl" suppressHydrationWarning>
      <body className="font-fa">
        <style>{`@font-face{font-family:Vazirmatn;src:url('${basePath}/fonts/vazirmatn-variable.woff2') format('woff2');font-weight:100 900;font-display:swap}`}</style>
        {children}
      </body>
    </html>
  );
}
