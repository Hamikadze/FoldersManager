using System;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable 4014

namespace FoldersManager
{
    // ReSharper disable once InconsistentNaming
    internal static class ErrorUtils
    {
        private static SoundPlayer ErrorSound;

        public static void Error(this Exception e)
        {
            Task.Factory.StartNew((() =>
            {
                try
                {
                    if (ErrorSound == null)
                    {
                        ErrorSound = new SoundPlayer("C:\\Windows\\Media\\Windows Error.wav");
                        ErrorSound.Load();
                    }
                    ErrorSound.Play();
                    MessageBox.Show($"{e.Message}\n{e}\n{e.TargetSite}\n", "Error!", MessageBoxButtons.OK);
                }
                catch (AccessViolationException)
                {
                }
                catch (Exception ex)
                {
                    Error(ex);
                }
            }));
        }
    }
}