using System.Drawing;
using System.Globalization;

namespace BadgeGenerator
{
    public class ColorScheme
    {
        public static string BrightGreen = "#4c1";
        public static string Green = "#97CA00";
        public static string Yellow = "#dfb317";
        public static string YellowGreen = "#a4a61d";
        public static string Orange = "#fe7d37";
        public static string Red = "#e05d44";
        public static string Blue = "#007ec6";
        public static string Grey = "#555";
        public static string Gray = "#555";
        public static string LightGrey = "#9f9f9f";
        public static string LightGray = "#9f9f9f";
    }

    public class BadgeGenerator
    {
	    private static readonly Font Font = new Font("DejaVu Sans,Verdana,Geneva,sans-serif", 11, FontStyle.Regular);
	    private static readonly Graphics G = Graphics.FromImage(new Bitmap(1, 1));
       const string Template = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""{0}"" height=""18"">
  <linearGradient id=""b"" x2=""0"" y2=""100%"">
    <stop offset=""0"" stop-color=""#fff"" stop-opacity="".7""/>
    <stop offset="".1"" stop-color=""#aaa"" stop-opacity="".1""/>
    <stop offset="".9"" stop-opacity="".3""/>
    <stop offset=""1"" stop-opacity="".5""/>
  </linearGradient>
  <mask id=""a"">
    <rect width=""{0}"" height=""18"" rx=""4"" fill=""#fff""/>
  </mask>
  <g mask=""url(#a)"">
    <path fill=""#555"" d=""M0 0h{1}v18H0z""/>
    <path fill=""{7}"" d=""M{1} 0h{2}v18H{1}z""/>
    <path fill=""url(#b)"" d=""M0 0h{0}v18H0z""/>
  </g>
  <g fill=""#fff"" text-anchor=""middle"" font-family=""DejaVu Sans,Verdana,Geneva,sans-serif"" font-size=""11"">
    <text x=""{3}"" y=""14"" fill=""#010101"" fill-opacity="".3"">{5}</text>
    <text x=""{3}"" y=""13"">{5}</text>
    <text x=""{4}"" y=""14"" fill=""#010101"" fill-opacity="".3"">{6}</text>
    <text x=""{4}"" y=""13"">{6}</text>
  </g>
</svg>";

	    public string Generate(string subject, string status, string statusColor)
        {
            var subjectWidth = G.MeasureString(subject, Font).Width;
            var statusWidth = G.MeasureString(status, Font).Width;

            return string.Format(
                CultureInfo.InvariantCulture, 
                Template,
                subjectWidth + statusWidth,
                subjectWidth,
                statusWidth,
                subjectWidth / 2 + 1,
                subjectWidth + statusWidth / 2 - 1,
                subject,
                status,
                statusColor);
        }
    }
}
