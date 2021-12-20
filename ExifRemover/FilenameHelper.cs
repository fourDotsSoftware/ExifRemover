using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExifRemover
{
    public class FilenameHelper
    {
        public static bool Overwrite = false;

        //public static int TotalIndex = 0;        

        public string TransformFilepath(string filepath)
        {
            string fn = Properties.Settings.Default.OFilenamePattern;                                    

            fn = fn.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath))
            .Replace("[EXT]", System.IO.Path.GetExtension(filepath).Substring(1).ToUpper());

            

            return fn;
        }                

        public string CalculateOutputFilepath(string filepath, string output_folder,string rootfolder)
        {                                              
            string outfp = "";

            string outfn = TransformFilepath(filepath); //System.IO.Path.GetFileNameWithoutExtension(filepath);
            
            string outfpdir = System.IO.Path.GetDirectoryName(filepath);

            /*
            cmbImageFormat.Items.Add("Same Format as Input");
            cmbImageFormat.Items.Add("PNG");
            cmbImageFormat.Items.Add("JPG");
            cmbImageFormat.Items.Add("JPEG");
            cmbImageFormat.Items.Add("GIF");
            cmbImageFormat.Items.Add("BMP");
            cmbImageFormat.Items.Add("TIFF");
            */

            string ext = System.IO.Path.GetExtension(filepath).ToLower().Substring(1);            

            outfn = outfn + "." + ext;

            if (output_folder == TranslateHelper.Translate("Overwrite Images"))
            {
                return filepath;
            }
            else if (output_folder == TranslateHelper.Translate("Same Folder of Image"))
            {                
                outfp = System.IO.Path.Combine(outfpdir, outfn);                
            }
            else if (!Module.IsLegalFilename(output_folder))
            {                
                int subfolderspos = output_folder.IndexOf(":") + 1;
                string subfolder = output_folder.Substring(subfolderspos).Trim();
                
                outfp = System.IO.Path.Combine(outfpdir + "\\" + subfolder, outfn);                
            }
            else
            {
                if (rootfolder != string.Empty && Properties.Settings.Default.OKeepFolderStrcture)
                {
                    string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                    string outdfp = output_folder + dep;

                    outfp = System.IO.Path.Combine(outdfp, outfn);                    
                }
                else
                {
                    outfp = System.IO.Path.Combine(output_folder, outfn);                    
                }
            }            

            return outfp;
        }

        public static string CalculateOutputZipFilepath(string filepath, string output_folder, string zipname,string zipext)
        {
            string outfp = "";

            string outfn = zipname;

            string outfpdir = System.IO.Path.GetDirectoryName(filepath);

            if (!outfn.ToLower().EndsWith(zipext.ToLower()))
            {
                outfn += zipext;
            }

            if (output_folder == TranslateHelper.Translate("Same Folder of Image"))
            {
                outfp = System.IO.Path.Combine(outfpdir, outfn);
            }
            else if (!Module.IsLegalFilename(output_folder))
            {
                int subfolderspos = output_folder.IndexOf(":") + 1;
                string subfolder = output_folder.Substring(subfolderspos).Trim();

                outfp = System.IO.Path.Combine(outfpdir + "\\" + subfolder, outfn);
            }
            else
            {
                outfp = System.IO.Path.Combine(output_folder, outfn);
            }

            return outfp;
        }
    }
}
