using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web;
using Spire.Doc;
namespace Core.Utility
{
    public class ShWord
    {
        // https://www.c-sharpcorner.com/uploadfile/38268a/create-word-document-from-win-form-with-users-data/
        private ShWord() { }
        private Document document = null;
        public void Relace(string findText, string replaceText)
        {
            document.Replace(findText, replaceText, true, true);
        }
        public static bool DoFileTemplate(string fileNameTemplate, Action<ShWord> action, Action<string> withFile, bool throwException = false)
        {
            if (!File.Exists(fileNameTemplate)) return false;
            var word = new ShWord { };
            try
            {
                word.document = new Document();
                word.document.LoadFromFile(fileNameTemplate);
                action(word);

                // Sinh ra file temp để lưu
                var folderTemp = HttpContext.Current.Server.MapPath("~/Web/Resources/Temps/WordTemps/");
                if (!Directory.Exists(folderTemp)) Directory.CreateDirectory(folderTemp);

                var fileTemp = folderTemp + "/" + "Word_" + DateTime.Now.ToString("dd_MM_yyyy_ss_tt_") + Singleton<Random>.Inst.Next(99999) + ".doc";

                word.document.SaveToFile(fileTemp, FileFormat.Docx);

                while (File.Exists(fileTemp)) break;
                //using (var file = File.Open(fileTemp, FileMode.Open)) withFile(file);
                //File.Delete(fileTemp);
                withFile(fileTemp);
            }
            finally
            {
                word.document.Close();
            }

            return true;
        }
    }
}