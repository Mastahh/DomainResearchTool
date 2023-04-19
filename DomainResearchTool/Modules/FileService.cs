using DomainResearchTool.Interfaces;
using DomainResearchTool.Models;

namespace DomainResearchTool.Modules
{
    public static class FileService
    {
        private static OpenFileDialog openFileDialog = new OpenFileDialog();
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();

        public static async Task<List<string>> OpenFile(string title="")
        {
            openFileDialog.Title = title;
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                return await ReadFile(selectedFile);
            }
            return new List<string>();
        }

        public static string SelectFile(string title = "")
        {
            openFileDialog.Title = title;
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        public static async Task<List<string>> ReadFile(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                var fileData = await File.ReadAllLinesAsync(filePath);
                return fileData.Select(el => el.Replace(" ", "")).Where(el => !string.IsNullOrWhiteSpace(el)).ToList();
            }
            return new List<string>();
        }

        public static async Task<List<string>> ReadCsvSkipFirst(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                List<string> result = new List<string>();
                var fileData = await File.ReadAllLinesAsync(filePath);
                foreach ( var line in fileData)
                {
                    result.AddRange(line.Split(',', StringSplitOptions.RemoveEmptyEntries).Skip(1));
                }
                return result;
            }
            return new List<string>();
        }

        public static async Task<List<string>> ReadCsvTakeFirstOnly(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                List<string> result = new List<string>();
                var fileData = await File.ReadAllLinesAsync(filePath);
                foreach (var line in fileData)
                {
                    result.Add(line.Split(',', StringSplitOptions.RemoveEmptyEntries).First());
                }
                return result;
            }
            return new List<string>();
        }

        public static async Task SaveDomains(IEnumerable<IDomainItem> domainItems)
        {
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var targetFile = saveFileDialog.FileName;
                try
                {
                    var domainToSave = domainItems.Select(el => el.ToFormatedString());
                    await File.WriteAllLinesAsync(targetFile, domainToSave);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CAnnot save to file.\r\n" + ex.Message, "Error", MessageBoxButtons.OKCancel);
                }

            }
                
        }
    }
}
