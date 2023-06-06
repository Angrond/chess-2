using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfsakk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,,] tabla = new string[8, 8, 3];  //0. réteg: mi van ott, 1. réteg: színe, 2. réteg: léphetőe
        Image[,] kepek;
        Button[,] gombok;
        string milep;
        int voltx;
        int volty;
        int promx = 0;
        int promy = 0;
        int lepesszam = 0;
        string szin;
        string target;
        string wpromote="white_queen";
        string bpromote = "black_queen";

        List<int> feherenpassant = new List<int>();
        List<int> feketeenpassant = new List<int>();
        Window1 w = new Window1();
        Window2 b = new Window2();

        BitmapImage lep = new BitmapImage(new Uri("/bin/debug/assets/lep.png", UriKind.Relative));
        BitmapImage mt = new BitmapImage(new Uri("/bin/debug/assets/mt.png", UriKind.Relative));
        BitmapImage attack = new BitmapImage(new Uri("/bin/debug/assets/attack.png", UriKind.Relative));
        BitmapImage white_bishop = new BitmapImage(new Uri("/bin/debug/assets/bishop_white.png", UriKind.Relative));
        BitmapImage white_knight = new BitmapImage(new Uri("/bin/debug/assets/knight_white.png", UriKind.Relative));     
        BitmapImage white_rook = new BitmapImage(new Uri("/bin/debug/assets/rook_white.png", UriKind.Relative));
        BitmapImage white_queen = new BitmapImage(new Uri("/bin/debug/assets/queen_white.png", UriKind.Relative));
        BitmapImage white_king = new BitmapImage(new Uri("/bin/debug/assets/king_white.png", UriKind.Relative));
        BitmapImage white_pawn = new BitmapImage(new Uri("/bin/debug/assets/pawn_white.png", UriKind.Relative));
        BitmapImage black_bishop = new BitmapImage(new Uri("/bin/debug/assets/bishop_black.png", UriKind.Relative));
        BitmapImage black_knight = new BitmapImage(new Uri("/bin/debug/assets/knight_black.png", UriKind.Relative));
        BitmapImage black_rook = new BitmapImage(new Uri("/bin/debug/assets/rook_black.png", UriKind.Relative));
        BitmapImage black_queen = new BitmapImage(new Uri("/bin/debug/assets/queen_black.png", UriKind.Relative));
        BitmapImage black_king = new BitmapImage(new Uri("/bin/debug/assets/king_black.png", UriKind.Relative));
        BitmapImage black_pawn = new BitmapImage(new Uri("/bin/debug/assets/pawn_black.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();
            kepek = new Image[8, 8] {
                { Img_a8, Img_b8, Img_c8, Img_d8, Img_e8, Img_f8, Img_g8, Img_h8 },
                { Img_a7, Img_b7, Img_c7, Img_d7, Img_e7, Img_f7, Img_g7, Img_h7 },
                { Img_a6, Img_b6, Img_c6, Img_d6, Img_e6, Img_f6, Img_g6, Img_h6 },
                { Img_a5, Img_b5, Img_c5, Img_d5, Img_e5, Img_f5, Img_g5, Img_h5 },
                { Img_a4, Img_b4, Img_c4, Img_d4, Img_e4, Img_f4, Img_g4, Img_h4 },
                { Img_a3, Img_b3, Img_c3, Img_d3, Img_e3, Img_f3, Img_g3, Img_h3 },
                { Img_a2, Img_b2, Img_c2, Img_d2, Img_e2, Img_f2, Img_g2, Img_h2 },
                { Img_a1, Img_b1, Img_c1, Img_d1, Img_e1, Img_f1, Img_g1, Img_h1 },
            };
            gombok = new Button[8,8] {
                { Btn_a8, Btn_b8, Btn_c8, Btn_d8, Btn_e8, Btn_f8, Btn_g8, Btn_h8 },
                { Btn_a7, Btn_b7, Btn_c7, Btn_d7, Btn_e7, Btn_f7, Btn_g7, Btn_h7 },
                { Btn_a6, Btn_b6, Btn_c6, Btn_d6, Btn_e6, Btn_f6, Btn_g6, Btn_h6 },
                { Btn_a5, Btn_b5, Btn_c5, Btn_d5, Btn_e5, Btn_f5, Btn_g5, Btn_h5 },
                { Btn_a4, Btn_b4, Btn_c4, Btn_d4, Btn_e4, Btn_f4, Btn_g4, Btn_h4 },
                { Btn_a3, Btn_b3, Btn_c3, Btn_d3, Btn_e3, Btn_f3, Btn_g3, Btn_h3 },
                { Btn_a2, Btn_b2, Btn_c2, Btn_d2, Btn_e2, Btn_f2, Btn_g2, Btn_h2 },
                { Btn_a1, Btn_b1, Btn_c1, Btn_d1, Btn_e1, Btn_f1, Btn_g1, Btn_h1 },
            };
            
            kezdes();
        }
        private bool sakke(int x, int y, string melyik) 
        {
            //ez jó mert megörjíti a programot :)
            /*for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tabla[i, j, 1] == melyik)
                    {
                        lepes(i, j);
                        if (tabla[x, y, 2] == ".")
                        {
                            reload();
                            return true;
                        }
                    }
                    
                }
            }
            reload();*/
            return false;
        }
        private void kezdes()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tabla[i, j, 0] = "-";
                    tabla[i, j, 1] = "-";
                    tabla[i, j, 2] = "-";
                }
            }  
        }
        private void leput(int x, int y) {
            if (tabla[x, y, 2] == ".")
            {
                if (tabla[x, y, 1].Contains("enpassant"))
                {
                    if (target=="b")
                    {
                        tabla[x + 1, y, 0] = "-";
                    }
                    if (target == "w")
                    {
                        tabla[x - 1, y, 0] = "-";
                    }
                }
                tabla[x, y, 0] = milep;
                if (milep=="white_pawn" && x == 0)
                {
                        wpromote = "white_queen";
                        w.Show();
                        w.wbishop.Click += Wbishop_Click;
                        w.wknight.Click += Wknight_Click;
                        w.wqueen.Click += Wqueen_Click;
                        w.wrook.Click += Wrook_Click;
                        w.Closing += W_Closing;
                        promx = x;
                        promy = y;
                }
                if (milep=="black_pawn" && x==7)
                {
                    bpromote = "black_queen";
                    b.Show();
                    b.bbishop.Click += Bbishop_Click;
                    b.bknight.Click += Bknight_Click;
                    b.bqueen.Click += Bqueen_Click;
                    b.brook.Click += Brook_Click;
                    b.Closing += B_Closing;
                    promx = x;
                    promy = y;
                }
                tabla[voltx, volty, 0] = "-";
                lepesszam++;
                reload();
            }
        }

        private void B_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tabla[promx, promy, 0] = bpromote;
            reload();
        }

        private void Brook_Click(object sender, RoutedEventArgs e)
        {
            bpromote = "black_rook";
            b.Close();
        }

        private void Bqueen_Click(object sender, RoutedEventArgs e)
        {
            bpromote = "black_queen";
            b.Close();
        }

        private void Bknight_Click(object sender, RoutedEventArgs e)
        {
            bpromote = "black_knight";
            b.Close();
        }

        private void Bbishop_Click(object sender, RoutedEventArgs e)
        {
            bpromote = "black_bishop";
            b.Close();
        }

        private void W_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tabla[promx, promy, 0] = wpromote;
            reload();
        }

        private void Wrook_Click(object sender, RoutedEventArgs e)
        {
            
            wpromote = "white_rook";
            w.Close();

        }

        private void Wqueen_Click(object sender, RoutedEventArgs e)
        {
            
            wpromote = "white_queen";
            w.Close();
        }

        private void Wknight_Click(object sender, RoutedEventArgs e)
        {
            
            wpromote = "white_knight";
            w.Close();
        }

        private void Wbishop_Click(object sender, RoutedEventArgs e)
        {
            
            wpromote = "white_bishop";
            w.Close();
        }

        private void lepes(int y, int x)
        {
            if (lepesszam % 2 == 0)
            {
                szin = "w";
                target = "b";
            }
            if (lepesszam % 2 == 1)
            {
                szin = "b";
                target = "w";
            }
            switch (tabla[x,y,0])
            {
                case "-":
                    leput(x, y);
                    reload();
                    break;
                case "white_bishop":
                    if (lepesszam % 2 == 0)
                    {

                        reload();
                        milep = "white_bishop";
                        voltx = x;
                        volty = y;
                        bishoplep(x, y);

                    }
                    else 
                    { 
                        leput(x, y);
                    }
                    
                    break;

                    
                case "white_knight":
                    if (lepesszam % 2 == 0)
                    {
                        reload();
                        milep = "white_knight";
                        voltx = x;
                        volty = y;
                        knightlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "white_rook":
                case "white_rooks":
                    if (lepesszam % 2 == 0)
                    {
                        reload();
                        milep = "white_rook";
                        voltx = x;
                        volty = y;
                        rooklep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "white_queen":
                    if (lepesszam % 2 == 0)
                    {
                        reload();
                        milep = "white_queen";
                        voltx = x;
                        volty = y;
                        queenlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "white_king":
                    if (lepesszam % 2 == 0)
                    {
                        reload();
                        milep = "white_king";
                        voltx = x;
                        volty = y;
                        kinglep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "white_pawn":
                    if (lepesszam % 2 == 0)
                    {
                        reload();
                        milep = "white_pawn";
                        voltx = x;
                        volty = y;
                        whitepawnlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;

                case "black_bishop":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_bishop";
                        voltx = x;
                        volty = y;
                        bishoplep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "black_knight":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_knight";
                        voltx = x;
                        volty = y;
                        knightlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "black_rook":
                case "black_rooks":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_rook";
                        voltx = x;
                        volty = y;
                        rooklep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "black_queen":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_queen";
                        voltx = x;
                        volty = y;
                        queenlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "black_king":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_king";
                        voltx = x;
                        volty = y;
                        kinglep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                case "black_pawn":
                    if (lepesszam % 2 == 1)
                    {
                        reload();
                        milep = "black_pawn";
                        voltx = x;
                        volty = y;
                        blackpawnlep(x, y);
                    }
                    else
                    {
                        leput(x, y);
                    }
                    break;
                
                default:
                    break;
            }
        }
        private void reload()
        {
            
            milep = "-";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string a = tabla[i, j, 1];

                    if (!tabla[i, j, 1].Contains("enpassant"))
                    {
                        tabla[i, j, 1] = "-";
                    }
                    else if (int.Parse(a.Remove(0,9))<lepesszam-1)
                    {
                        tabla[i, j, 1] = "-";
                    }
                    
                    tabla[i, j, 2] = "-";
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (tabla[i,j, 0])
                    {
                        case "-":
                            kepek[i,j].Source= mt;
                            tabla[i, j, 0] = "-";
                            break;
                            //white
                        case "white_bishop":
                            kepek[i, j].Source = white_bishop;
                            tabla[i, j, 1] = "w";
                            break;
                        case "white_knight":
                            kepek[i, j].Source = white_knight;
                            tabla[i, j, 1] = "w";
                            break;
                        case "white_rook":
                        case "white_rooks":
                            kepek[i, j].Source = white_rook;
                            tabla[i, j, 1] = "w";
                            break;
                        case "white_queen":
                            kepek[i, j].Source = white_queen;
                            tabla[i, j, 1] = "w";
                            break;
                        case "white_king":
                            kepek[i, j].Source = white_king;
                            tabla[i, j, 1] = "w";
                            break;
                        case "white_pawn":
                            kepek[i, j].Source = white_pawn;
                            tabla[i, j, 1] = "w";
                            break;
                            //black
                        case "black_bishop":
                            kepek[i, j].Source = black_bishop;
                            tabla[i, j, 1] = "b";
                            break;
                        case "black_knight":
                            kepek[i, j].Source = black_knight;
                            tabla[i, j, 1] = "b";
                            break;
                        case "black_rook":
                        case "black_rooks":
                            kepek[i, j].Source = black_rook;
                            tabla[i, j, 1] = "b";
                            break;
                        case "black_queen":
                            kepek[i, j].Source = black_queen;
                            tabla[i, j, 1] = "b";
                            break;
                        case "black_king":
                            kepek[i, j].Source = black_king;
                            tabla[i, j, 1] = "b";
                            break;
                        case "black_pawn":
                            kepek[i, j].Source = black_pawn;
                            tabla[i, j, 1] = "b";
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void bishoplep(int x, int y)
        {
            
            bool bishoptakar1 = false;
            bool bishoptakar2 = false;
            bool bishoptakar3 = false;
            bool bishoptakar4 = false;
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if (tabla[x + i, y + i,0] == "-" && !bishoptakar1)
                    {
                        kepek[x + i, y + i].Source = lep;
                        tabla[x + i, y + i, 2] = ".";
                    }
                    else
                    {
                        if (tabla[x + i, y + i, 1] == target)
                        {
                            tabla[x + i, y + i, 2] = ".";
                        }
                            bishoptakar1 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {

                    if (tabla[x - i, y + i, 0] == "-" && !bishoptakar2)
                    {
                        kepek[x - i, y + i].Source = lep;
                        tabla[x - i, y + i, 2] = ".";
                    }
                    else
                    {
                        if (tabla[x - i, y + i, 1] == target)
                        {
                            tabla[x - i, y + i, 2] = ".";
                        }
                        bishoptakar2 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {
                    if (tabla[x + i, y - i, 0] == "-" && !bishoptakar3)
                    {
                        kepek[x + i, y - i].Source = lep;
                        tabla[x + i, y - i, 2] = ".";
                    }
                    else 
                    {
                        if (tabla[x + i, y - i, 1] == target)
                        {
                            tabla[x + i, y - i, 2] = ".";
                        }
                        bishoptakar3 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {
                    if (tabla[x - i, y - i, 0] == "-" && !bishoptakar4)
                    {
                        kepek[x - i, y - i].Source = lep;
                        tabla[x - i, y - i, 2] = ".";
                    }
                    else 
                    {
                        if (tabla[x - i, y - i, 1] == target)
                        {
                            tabla[x - i, y - i, 2] = ".";
                        }
                        bishoptakar4 = true;
                    }
                }
                catch (Exception)
                {


                }
            }
        }
        private void knightlep(int x, int y)
        {
            
            try
            {
                if (tabla[x + 2, y + 1, 0] == "-")
                {
                    tabla[x + 2, y + 1, 2] = ".";
                    kepek[x + 2, y + 1].Source = lep;
                }
                else 
                {
                    if (tabla[x + 2, y + 1, 1] == target)
                    {
                        tabla[x + 2, y + 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x + 2, y - 1, 0] == "-")
                {
                    tabla[x + 2, y - 1, 2] = ".";
                    kepek[x + 2, y - 1].Source = lep;
                }
                else 
                {
                    if (tabla[x + 2, y - 1, 1] == target)
                    {
                        tabla[x + 2, y - 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x - 2, y - 1, 0] == "-")
                {
                    tabla[x - 2, y - 1, 2] = ".";
                    kepek[x - 2, y - 1].Source = lep;
                }
                else
                {
                    if (tabla[x - 2, y - 1, 1] == target)
                    {
                        tabla[x - 2, y - 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x - 2, y + 1, 0] == "-")
                {
                    tabla[x - 2, y + 1, 2] = ".";
                    kepek[x - 2, y + 1].Source = lep;
                }
                else
                {
                    if (tabla[x - 2, y + 1, 1] == target)
                    {
                        tabla[x - 2, y + 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x + 1, y + 2, 0] == "-")
                {
                    tabla[x + 1, y + 2, 2] = ".";
                    kepek[x + 1, y + 2].Source = lep;
                }
                else 
                {
                    if (tabla[x + 1, y + 2, 1] == target)
                    {
                        tabla[x + 1, y + 2, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x + 1, y - 2, 0] == "-")
                {
                    tabla[x + 1, y - 2, 2] = ".";
                    kepek[x + 1, y - 2].Source = lep;
                }
                else
                {
                    if (tabla[x + 1, y - 2, 1] == target)
                    {
                        tabla[x + 1, y - 2, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x - 1, y - 2, 0] == "-")
                {
                    tabla[x - 1, y - 2, 2] = ".";
                    kepek[x - 1, y - 2].Source = lep;
                }
                else
                {
                    if (tabla[x - 1, y - 2, 1] == target)
                    {
                        tabla[x - 1, y - 2, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (tabla[x - 1, y + 2, 0] == "-")
                {
                    tabla[x - 1, y + 2, 2] = ".";
                    kepek[x - 1, y + 2].Source = lep;
                }
                else
                {
                    if (tabla[x - 1, y + 2, 1] == target)
                    {
                        tabla[x - 1, y + 2, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void rooklep(int x, int y)
        {
            
            bool rooktakar1 = false;
            bool rooktakar2 = false;
            bool rooktakar3 = false;
            bool rooktakar4 = false;
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x + i, y, 0] == "-" && !rooktakar1)
                    {
                        tabla[x + i, y, 2] = ".";
                        kepek[x + i, y].Source = lep;
                    }
                    else
                    {
                        if (tabla[x + i, y, 1] == target)
                        {
                            tabla[x + i, y, 2] = ".";
                        }
                        rooktakar1 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x - i, y, 0] == "-" && !rooktakar2)
                    {
                        tabla[x - i, y, 2] = ".";
                        kepek[x - i, y].Source = lep;
                    }
                    else
                    {
                        if (tabla[x - i, y, 1] == target)
                        {
                            tabla[x - i, y, 2] = ".";
                        }
                        rooktakar2 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x, y + i, 0] == "-" && !rooktakar3)
                    {
                        tabla[x, y + i, 2] = ".";
                        kepek[x, y + i].Source = lep;
                    }
                    else
                    {
                        if (tabla[x, y + i, 1] == target)
                        {
                            tabla[x, y + i, 2] = ".";
                        }
                        rooktakar3 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x, y - i, 0] == "-" && !rooktakar4)
                    {
                        tabla[x, y - i, 2] = ".";
                        kepek[x, y - i].Source = lep;
                    }
                    else
                    {
                        if (tabla[x, y - i, 1] == target)
                        {
                            tabla[x, y - i, 2] = ".";
                        }
                        rooktakar4 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void queenlep(int x, int y)
        {
            
            bool queentakar1 = false;
            bool queentakar2 = false;
            bool queentakar3 = false;
            bool queentakar4 = false;
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if (tabla[x + i, y + i,0] == "-" && !queentakar1)
                    {
                        kepek[x + i, y + i].Source = lep;
                        tabla[x + i, y + i,2] = ".";
                    }
                    else
                    {
                        if (tabla[x + i, y + i, 1] == target)
                        {
                            tabla[x + i, y + i, 2] = ".";
                        }
                        queentakar1 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {

                    if (tabla[x - i, y + i,0] == "-" && !queentakar2)
                    {
                        kepek[x - i, y + i].Source = lep;
                        tabla[x - i, y + i,2] = ".";
                    }
                    else 
                    {
                        if (tabla[x - i, y + i, 1] == target)
                        {
                            tabla[x - i, y + i, 2] = ".";
                        }
                        queentakar2 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {
                    if (tabla[x + i, y - i,0] == "-" && !queentakar3)
                    {
                        kepek[x + i, y - i].Source = lep;
                        tabla[x + i, y - i,2] = ".";
                    }
                    else 
                    {
                        if (tabla[x + i, y - i, 1] == target)
                        {
                            tabla[x + i, y - i, 2] = ".";
                        }
                        queentakar3 = true;
                    }
                }
                catch (Exception)
                {


                }
                try
                {
                    if (tabla[x - i, y - i,0] == "-" && !queentakar4)
                    {
                        kepek[x - i, y - i].Source = lep;
                        tabla[x - i, y - i,2] = ".";
                    }
                    else 
                    {
                        if (tabla[x - i, y - i, 1] == target)
                        {
                            tabla[x - i, y - i, 2] = ".";
                        }
                        queentakar4 = true;
                    }
                }
                catch (Exception)
                {


                }
            }
            bool queentakar5 = false;
            bool queentakar6 = false;
            bool queentakar7 = false;
            bool queentakar8 = false;
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x + i, y,0] == "-" && !queentakar5)
                    {
                        tabla[x + i, y,2] = ".";
                        kepek[x + i, y].Source = lep;
                    }
                    else
                    {
                        if (tabla[x + i, y, 1] == target)
                        {
                            tabla[x + i, y, 2] = ".";
                        }
                        queentakar5 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x - i, y,0] == "-" && !queentakar6)
                    {
                        tabla[x - i, y,2] = ".";
                        kepek[x - i, y].Source = lep;
                    }
                    else
                    {
                        if (tabla[x - i, y, 1] == target)
                        {
                            tabla[x - i, y, 2] = ".";
                        }
                        queentakar6 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x, y + i, 0] == "-" && !queentakar7)
                    {
                        tabla[x, y + i, 2] = ".";
                        kepek[x, y + i].Source = lep;
                    }
                    else
                    {
                        if (tabla[x, y + i, 1] == target)
                        {
                            tabla[x, y + i, 2] = ".";
                        }
                        queentakar7 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                for (int i = 1; i < 8; i++)
                {
                    if (tabla[x, y - i, 0] == "-" && !queentakar8)
                    {
                        tabla[x, y - i, 2] = ".";
                        kepek[x, y - i].Source = lep;
                    }
                    else
                    {
                        if (tabla[x, y - i, 1] == target)
                        {
                            tabla[x, y - i, 2] = ".";
                        }
                        queentakar8 = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void kinglep(int x, int y)
        {
            
            try
            {
                if (tabla[x + 1, y,0] == "-" && !sakke(x+1,y,target))
                {
                    kepek[x + 1, y].Source = lep;
                    tabla[x + 1, y,2] = ".";
                }
                else
                {
                    if (tabla[x + 1, y, 1] == target)
                    {
                        tabla[x + 1, y, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x + 1, y+1,0] == "-" && !sakke(x + 1, y+1, target))
                {
                    kepek[x + 1, y+1].Source = lep;
                    tabla[x + 1, y+1,2] = ".";
                }
                else
                {
                    if (tabla[x + 1, y + 1, 1] == target)
                    {
                        tabla[x + 1, y + 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x + 1, y - 1,0] == "-" && !sakke(x + 1, y-1, target))
                {
                    kepek[x + 1, y - 1].Source = lep;
                    tabla[x + 1, y - 1,2] = ".";
                }
                else
                {
                    if (tabla[x + 1, y - 1, 1] == target)
                    {
                        tabla[x + 1, y - 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x - 1, y,0] == "-" && !sakke(x - 1, y, target))
                {
                    kepek[x - 1, y].Source = lep;
                    tabla[x - 1, y,2] = ".";
                }
                else
                {
                    if (tabla[x - 1, y, 1] == target)
                    {
                        tabla[x - 1, y, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x - 1, y - 1,0] == "-" && !sakke(x - 1, y - 1, target))
                {
                    kepek[x - 1, y - 1].Source = lep;
                    tabla[x - 1, y - 1,2] = ".";
                }
                else
                {
                    if (tabla[x - 1, y - 1, 1] == target)
                    {
                        tabla[x - 1, y - 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x - 1, y + 1,0] == "-" && !sakke(x - 1, y+1, target))
                {
                    kepek[x - 1, y + 1].Source = lep;
                    tabla[x - 1, y + 1,2] = ".";
                }
                else
                {
                    if (tabla[x - 1, y + 1, 1] == target)
                    {
                        tabla[x - 1, y + 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x, y + 1,0] == "-" && !sakke(x, y+1, target))
                {
                    kepek[x, y + 1].Source = lep;
                    tabla[x, y + 1,2] = ".";
                }
                else
                {
                    if (tabla[x, y + 1, 1] == target)
                    {
                        tabla[x, y + 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (tabla[x, y - 1,0] == "-" && !sakke(x, y-1, target))
                {
                    kepek[x, y - 1].Source = lep;
                    tabla[x, y - 1,2] = ".";
                }
                else
                {
                    if (tabla[x, y - 1, 1] == target)
                    {
                        tabla[x, y - 1, 2] = ".";
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void whitepawnlep(int x, int y)
        {
            
            if (x==6)
            {
                if (tabla[x - 2, y,0] == "-" && tabla[x - 1, y, 0] == "-")
                {
                    kepek[x - 2, y].Source = lep;
                    tabla[x - 1, y, 1] = "enpassant"+lepesszam;
                    tabla[x - 2, y,2] = ".";
                }
                
            }
            try
            {
                if (tabla[x - 1, y,0] == "-")
                {
                    kepek[x - 1, y].Source = lep;
                    tabla[x - 1, y,2] = ".";
                }
                if (tabla [x-1, y-1,1]==target || tabla[x - 1, y - 1, 1].Contains("enpassant"))
                {
                    
                    tabla[x - 1, y-1, 2] = ".";
                }
                if (tabla[x - 1, y + 1, 1] == target || tabla[x - 1, y + 1, 1].Contains("enpassant"))
                {
                    
                    tabla[x - 1, y + 1, 2] = ".";
                }
            }
            catch (Exception)
            {

            }
        }
        private void blackpawnlep(int x, int y)
        {
            
            if (x == 1)
            {
                if (tabla[x + 2, y,0] == "-" && tabla[x + 1, y, 0] == "-")
                {
                    kepek[x + 2, y].Source = lep;
                    tabla[x + 1, y, 1] = "enpassant" + lepesszam;
                    tabla[x + 2, y,2] = ".";

                }
            }
            try
            {
                if (tabla[x + 1, y,0] == "-")
                {
                    kepek[x + 1, y].Source = lep;
                    tabla[x + 1, y,2] = ".";
                }
                if (tabla[x + 1, y - 1, 1] == target || tabla[x + 1, y - 1, 1].Contains("enpassant"))
                {
                    
                    tabla[x + 1, y - 1, 2] = ".";
                }
                if (tabla[x + 1, y + 1, 1] == target || tabla[x + 1, y + 1, 1].Contains("enpassant"))
                {
                    
                    tabla[x + 1, y + 1, 2] = ".";
                }
            }
            catch (Exception)
            {

            }
        }
        private void Btn_a8_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 0);
        }

        private void Btn_a7_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 1);
        }

        private void Btn_a6_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 2);
        }

        private void Btn_a5_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 3);
        }

        private void Btn_a4_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 4);
        }

        private void Btn_a3_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 5);
        }

        private void Btn_a2_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 6);
        }

        private void Btn_a1_Click(object sender, RoutedEventArgs e)
        {
            lepes(0, 7);
        }

        private void Btn_b8_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 0);
        }

        private void Btn_b7_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 1);
        }

        private void Btn_b6_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 2);
        }

        private void Btn_b5_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 3);
        }

        private void Btn_b4_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 4);
        }

        private void Btn_b3_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 5);
        }

        private void Btn_b2_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 6);
        }

        private void Btn_b1_Click(object sender, RoutedEventArgs e)
        {
            lepes(1, 7);
        }

        private void Btn_c8_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 0);
        }

        private void Btn_c7_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 1);
        }

        private void Btn_c6_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 2);
        }

        private void Btn_c5_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 3);
        }

        private void Btn_c4_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 4);
        }

        private void Btn_c3_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 5);
        }

        private void Btn_c2_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 6);
        }

        private void Btn_c1_Click(object sender, RoutedEventArgs e)
        {
            lepes(2, 7);
        }

        private void Btn_d8_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 0);
        }

        private void Btn_d7_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 1);
        }

        private void Btn_d6_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 2);
        }

        private void Btn_d5_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 3);
        }

        private void Btn_d4_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 4);
        }

        private void Btn_d3_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 5);
        }

        private void Btn_d2_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 6);
        }

        private void Btn_d1_Click(object sender, RoutedEventArgs e)
        {
            lepes(3, 7);
        }

        private void Btn_e8_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 0);
        }

        private void Btn_e7_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 1);
        }

        private void Btn_e6_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 2);
        }

        private void Btn_e5_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 3);
        }

        private void Btn_e4_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 4);
        }

        private void Btn_e3_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 5);
        }

        private void Btn_e2_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 6);
        }

        private void Btn_e1_Click(object sender, RoutedEventArgs e)
        {
            lepes(4, 7);
        }

        private void Btn_f8_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 0);
        }

        private void Btn_f7_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 1);
        }

        private void Btn_f6_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 2);
        }

        private void Btn_f5_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 3);
        }

        private void Btn_f4_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 4);
        }

        private void Btn_f3_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 5);
        }

        private void Btn_f2_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 6);
        }

        private void Btn_f1_Click(object sender, RoutedEventArgs e)
        {
            lepes(5, 7);
        }

        private void Btn_g8_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 0);
        }

        private void Btn_g7_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 1);
        }

        private void Btn_g6_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 2);
        }

        private void Btn_g5_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 3);
        }

        private void Btn_g4_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 4);
        }

        private void Btn_g3_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 5);
        }

        private void Btn_g2_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 6);
        }

        private void Btn_g1_Click(object sender, RoutedEventArgs e)
        {
            lepes(6, 7);
        }

        private void Btn_h8_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 0);
        }

        private void Btn_h7_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 1);
        }

        private void Btn_h6_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 2);
        }

        private void Btn_h5_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 3);
        }

        private void Btn_h4_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 4);
        }

        private void Btn_h3_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 5);
        }

        private void Btn_h2_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 6);
        }

        private void Btn_h1_Click(object sender, RoutedEventArgs e)
        {
            lepes(7, 7);
        }

        private void Horsey_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "white_knight";
            
            reload();
        }

        private void Rook_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "white_rook";
            
            reload();
        }

        private void Queen_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "white_queen";

            reload();
        }

        private void King_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "white_king";

            reload();
        }

        private void Pawn_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "-";
            tabla[1, 4,0] = "white_pawn";
            tabla[6, 4, 0] = "black_pawn";
            reload();
        }

        private void Bishop_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            tabla[4, 4,0] = "white_bishop";

            reload();
        }

        private void Alap_Click(object sender, RoutedEventArgs e)
        {
            kezdes();
            
            tabla[0, 0, 0] = "black_rooks";
            tabla[0, 7, 0] = "black_rooks";
            tabla[0, 1, 0] = "black_knight";
            tabla[0, 6, 0] = "black_knight";
            tabla[0, 2, 0] = "black_bishop";
            tabla[0, 5, 0] = "black_bishop";
            tabla[0, 4, 0] = "black_king";
            tabla[0, 3, 0] = "black_queen";
            for (int i = 0; i < 8; i++)
            {
                tabla[1, i, 0] = "black_pawn";
                tabla[6, i, 0] = "white_pawn";

            }
            tabla[7, 0, 0] = "white_rooks";
            tabla[7, 7, 0] = "white_rooks";
            tabla[7, 1, 0] = "white_knight";
            tabla[7, 6, 0] = "white_knight";
            tabla[7, 2, 0] = "white_bishop";
            tabla[7, 5, 0] = "white_bishop";
            tabla[7, 4, 0] = "white_king";
            tabla[7, 3, 0] = "white_queen";
            reload();
        }
    }
}
