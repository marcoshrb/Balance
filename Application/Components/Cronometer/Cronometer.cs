using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Components
{
    public class Stopwatch
    {
        public Label time;
        RectangleF background;
        RectangleF border;
        public DateTime target;

        public Stopwatch(PointF location, SizeF size)
        {
            size.Width = size.Width * ClientScreen.WidthFactor;
            size.Height = size.Height * ClientScreen.HeightFactor;

            location.X = location.X * ClientScreen.WidthFactor;
            location.Y = location.Y * ClientScreen.HeightFactor;

            this.time = new Label
            {
                Text = "Time",
                Size = new Size(
                            (int)(size.Width - 15 * ClientScreen.WidthFactor),
                            (int)(size.Height * ClientScreen.HeightFactor - 15 * ClientScreen.HeightFactor)
                        ),
                BackColor = Color.Transparent,
                Font = new Font("Arial", 52 * ClientScreen.WidthFactor, FontStyle.Bold),
                Location = new Point(
                                (int)(location.X + 60 * ClientScreen.WidthFactor),
                                (int)location.Y
                            ),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            this.background = new RectangleF
            (
                new PointF(
                    location.X + 5 * ClientScreen.WidthFactor,
                    location.Y + 5 * ClientScreen.HeightFactor
                ),
                new SizeF(
                    size.Width - 10 * ClientScreen.WidthFactor,
                    size.Height - 10 * ClientScreen.HeightFactor
                )
            );

            this.border = new RectangleF
            (
                new PointF(
                    location.X,
                    location.Y
                ),
                new SizeF(
                    size.Width,
                    size.Height
                )
            );

            try
            {
                target = DateTime.Now.AddMinutes(UserData.Current.JsonValues.TempoProva);
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
                target = DateTime.Now.AddMinutes(10);
            }

        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Black, this.border);
            g.FillRectangle(Brushes.White, this.background);
            g.DrawString(time.Text, time.Font, Brushes.Black, time.Location);
        }
        public void DrawAwait(Graphics g)
        {
            g.FillRectangle(Brushes.Black, this.border);
            g.FillRectangle(Brushes.White, this.background);
            g.DrawString("Aguarde", time.Font, Brushes.Black, time.Location.X - 55 * ClientScreen.WidthFactor, time.Location.Y);
        }

        public void Update()
            => this.time.Text = string.Format("{0:mm\\:ss}", GetTimeDifference());

        public TimeSpan GetTimeDifference()
            => this.target - DateTime.Now;
    }
}
