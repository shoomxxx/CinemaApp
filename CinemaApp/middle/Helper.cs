using System;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace CinemaApp.middle
{
    public class Helper
    {
        private readonly FileInfo _fileInfo;

        public Helper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {//todo:  словарь явялется результатом рефлексии над клиентом: а не собирается руками
            //todo: переехать на объектную модель openxml sdk ( название нугета есть в чатике)
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    var find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace
                    );
                }

                if (_fileInfo.DirectoryName != null)
                {
                    Object newFileName = Path.Combine(_fileInfo.DirectoryName,
                        DateTime.Now.ToString("yyyyMMdd HHmmss ") + Guid.NewGuid() + _fileInfo.Name);
                    app.ActiveDocument.SaveAs2(newFileName);
                }

                app.ActiveDocument.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                app?.Quit();
            }

            return false;
        }
    }
}