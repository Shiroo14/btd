using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace btd
{
    public partial class Form1 : Form
    {
        public static int hide = 0;

        //マウスのクリック位置を記憶
        private Point mousePoint;
        //マウスのボタン押されたとき
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //マウス左ボタンで後ろに隠す
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.TopMost = false;
                this.SendToBack();
                Form1.hide = 5; //隠す秒数を指定
            }
            //マウス右ボタンで移動
            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                mousePoint = new Point(e.X, e.Y);   //位置を記憶する
            }
        }
        //マウスが動いたとき
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //マウス右ボタンで移動
            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        // 更新時間ごとに呼ばれるfunction
        private void timer1_Tick(object sender, EventArgs e)
        {
            String datestr = "", timestr = "", btrpctstr = "", btrtstr = "", tipsstr = "";
            const int fuchi = 5;

            //日付と時刻の取得
            DateTime dt = DateTime.Now;
            //str = dt.ToString("yyyy/MM/dd HH:mm:ss");
            datestr = dt.ToString("M/d(ddd) ");
            timestr = dt.ToString("H:mm ");

            //バッテリーの充電状態を取得する
            BatteryChargeStatus bcs = SystemInformation.PowerStatus.BatteryChargeStatus;

            //バッテリー残量（割合）
            float blp = SystemInformation.PowerStatus.BatteryLifePercent;
            btrpctstr = blp * 100 + "%";
            tipsstr = timestr + " " + datestr + " " + btrpctstr;

            //バッテリー残量（時間）
            int blr = SystemInformation.PowerStatus.BatteryLifeRemaining;
            if (-1 < blr)
            {
                var span = new TimeSpan(0, 0, blr);  // TimeSpanのインスタンスを生成。時分は0でOK
                if (Program.nbt == true)
                {
                    btrtstr = span.ToString(@"h\:mm");
                }
                tipsstr += " " + span.ToString(@"h\:mm");

                if (Program.nbet == true)
                {
                    span = new TimeSpan(dt.Hour, dt.Minute, dt.Second + blr);  // TimeSpanのインスタンスを生成。バッテリー残り時間+現在時間 = 推定バッテリー終了時間
                    if (btrtstr != "") btrtstr += "/";
                    btrtstr += span.ToString(@"h\:mm");
                }
                if (btrtstr != "") btrtstr = "[" + btrtstr + "]";
            }

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);
            //GraphicsPathオブジェクトの作成
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //StringFormatオブジェクトの作成
            StringFormat sf = new StringFormat();
            FontFamily fntFamily = new FontFamily("メイリオ");

            //GraphicsPathに文字列を追加する/////////////////////////////////
            RectangleF rectstring;
            int gpx = fuchi;

            // 時刻
            rectstring = gp.GetBounds();
            gpx = (int)(rectstring.X + rectstring.Width);
            if (Program.nt == true)
                gp.AddString(" " + timestr, fntFamily, (int)FontStyle.Bold, 15, new Point(gpx, fuchi), sf);

            // 日付
            rectstring = gp.GetBounds();
            gpx = (int)(rectstring.X + rectstring.Width);
            if (Program.nd == true)
                gp.AddString("  " + datestr, fntFamily, (int)FontStyle.Bold, 11, new Point(gpx, fuchi + 1), sf);

            // バッテリー%
            rectstring = gp.GetBounds();
            gpx = (int)(rectstring.X + rectstring.Width);
            gp.AddString("  " + btrpctstr, fntFamily, (int)FontStyle.Bold, 12, new Point(gpx, fuchi + 1), sf);

            // バッテリー残り時間
            rectstring = gp.GetBounds();
            gpx = (int)(rectstring.X + rectstring.Width);
            gp.AddString(" " + btrtstr, fntFamily, (int)FontStyle.Regular, 11, new Point(gpx, fuchi + 1), sf);

            // フチを描く
            g.DrawPath(new Pen(Color.Black, fuchi), gp);
            //文字列の中を塗りつぶす
            g.FillPath(Brushes.White, gp);

            //PictureBox1に表示する
            pictureBox1.Image = canvas;
            rectstring = gp.GetBounds();
            pictureBox1.Width = (int)(rectstring.X + rectstring.Width + fuchi);
            pictureBox1.Height = (int)(rectstring.Y + rectstring.Height + fuchi);

            //ToolTip更新
            ToolTip1.SetToolTip(pictureBox1, tipsstr);

            //後ろに隠れたwindowを最前面に戻す
            if(Form1.hide != 0)
            {
                Form1.hide -= 1;
                if (Form1.hide == 0)
                {
                    this.Activate();
                    this.TopMost = true;
                }
            }

            //リソースを解放する
            fntFamily.Dispose();
            sf.Dispose();
            g.Dispose();
            gp.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            timer1.Interval = 1000;    //更新間隔dummy(初期表示用)
            timer1.Enabled = true;
            Form1.hide = 0;
        }

        public static ToolTip ToolTip1;
        public Form1(int x, int y)
        {
            InitializeComponent();

            //タイトルバーを消す
            this.Text = "";
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            // フォームで透過色を設定する. フォーム（this）のTransparencyKeyプロパティに透明で表示する色を指定
            this.TransparencyKey = Color.Red;

            // form全体を半透明にする
            this.Opacity = 0.5;

            // フォームを最上位フォームにする
            this.TopMost = true;
            this.Show();

            // 座標
            this.Location = new Point(x, y);

            // マウス移動イベントを追加
            pictureBox1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(Form1_MouseMove);

            //ToolTip表示
            ToolTip1 = new ToolTip(this.components);
            ToolTip1.InitialDelay = 100;    //ToolTipが表示されるまでの時間
            //ToolTip1.ReshowDelay = 8000;  //ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            //ToolTip1.AutoPopDelay = 5;  //ToolTipを表示する時間
            ToolTip1.ShowAlways = false;    //フォームがアクティブでない時でもToolTipを表示する
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void Powercfg(int maxval)
        {
            // 第1引数がコマンド、第2引数がコマンドの引数
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            ("cmd.exe", "/c powercfg /SETDCVALUEINDEX SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX "+ maxval +
             " & powercfg /SETACVALUEINDEX SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX "+ maxval +
             " & powercfg /SETACTIVE SCHEME_CURRENT");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false; // シェル機能を使用しない
            Process process = Process.Start(processStartInfo);    // コマンド実行
            process.WaitForExit();
            process.Close();
        }
        private void MenuItem100_Click(object sender, EventArgs e)
        {
            Form1.Powercfg(100);
        }
        private void MenuItem75_Click(object sender, EventArgs e)
        {
            Form1.Powercfg(75);
        }
        private void MenuItem50_Click(object sender, EventArgs e)
        {
            Form1.Powercfg(50);
        }
        private void MenuItem25_Click(object sender, EventArgs e)
        {
            Form1.Powercfg(25);
        }

        private void inputValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
// (参考page)
// バッテリー残量取得
// https://among-ev.hatenadiary.org/entry/20101023/1287829524
// 
// 秒からhh:mmに変換
// https://qiita.com/Nossa/items/70487b765ec9332e0db0
//
// 文字の縁取り
// https://dobon.net/vb/dotnet/graphics/drawoutlinestring.html
//
// timer処理
// https://dianxnao.com/cs%E3%83%87%E3%82%B8%E3%82%BF%E3%83%AB%E6%99%82%E8%A8%88%E3%82%92%E4%BD%9C%E3%82%8B/
//
// 日付・時刻の取得
// https://www.fenet.jp/dotnet/column/language/2152/
// 曜日の取得
// https://atmarkit.itmedia.co.jp/ait/articles/1710/04/news017.html
//
// 文字列の検索と位置
// https://itsakura.com/csharp-indexof
//
// グローバル変数もどき
// https://www.sejuku.net/blog/102720
//
// tooltip表示
// https://dobon.net/vb/dotnet/control/showtooltip.html
//
// 文字を数字に変換
// https://www.sejuku.net/blog/44977
//
// フォームを後ろに隠す
// https://dobon.net/vb/bbs/log3-8/4634.html
//
// C#でbatteryreport実行, 返値取得
// https://social.msdn.microsoft.com/Forums/pt-BR/55a01443-f755-49c7-a1bb-3f24b32aab62/cbatteryreport?forum=windowsgeneraldevelopmentissuesja
// https://www.itlab51.com/?p=4815
//
// 数字box
// https://imagingsolution.net/program/csharp/numericupdown_control/
//
// フォームを開く/閉じる
// https://johobase.com/windows-form-show-close/
// https://www.fenet.jp/dotnet/column/language/4062/
//
// 文字列読み込み,検索,切り出し
// https://dobon.net/vb/dotnet/string/readline.html
// https://www.fenet.jp/infla/column/technology/c%E3%81%AE%E6%96%87%E5%AD%97%E5%88%97%E6%A4%9C%E7%B4%A2%E3%82%92%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC%E3%81%97%E3%82%88%E3%81%86%EF%BC%81/
// https://www.fenet.jp/dotnet/column/language/4198/
//
// Enterキーでクリックされるボタン
// https://johobase.com/windows-form-button-accept-cancel/

