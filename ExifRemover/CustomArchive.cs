using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;

namespace ExifRemover
{
    public class CustomArchive
    {
        public static bool SKIP_ALL_ARCHIVES_WITH_PASSWORDS = false;
        private string UncompressedDirectoryPath = "";

        public static string TempDirectoryPath = System.IO.Path.GetTempPath() + Module.ApplicationName + "\\";
        
        public string Filepath = "";
        public string Password = "";

        public static string ArchivveRegExPattern
        =@".*\.zip|.*\.rar|.*\.bz2|.*\.gz|.*\.gzip|.*\.bzip2|.*\.bz|.*\.tar";

        public CustomArchive(string filepath, string password)
        {
            Filepath = filepath;

            Password = password;
        }

        public static bool IsArchive(string filepath)
        {
            filepath = filepath.ToLower();
            string ext=System.IO.Path.GetExtension(filepath);
            
            //*.zip;*.rar;*.bz2;*.gz;*.gzip;*.bzip2;*.bz;*.tar;
            //*.zip|||*.rar|||*.bz2|||*.gz|||*.gzip|||*.bzip2|||*.bz|||*.tar|||
            if (ext.Equals(".zip") || ext.Equals(".rar")
                || ext.Equals(".bz2") || ext.Equals(".gz") || ext.Equals(".gzip") || ext.Equals(".bzip2") || ext.Equals(".bz")
                || ext.Equals(".tar"))
            {
                return true;

                /*
                if (!FileListHelper.regex_compressed_part_file.IsMatch(filepath))
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
            }
            else
            {
                return false;
            }
        }

        public CustomExtractedFilesInfo DecompressArchive()
        {
            string filepath = Filepath.ToLower();
            string ext=System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".zip"))
            {
                return DecompressArchiveZip();
            }
            else if (ext.Equals(".rar"))
            {
                return DecompressArchiveRar();
            }
            else if (ext.Equals(".bz2") || ext.Equals(".bzip2") || ext.Equals(".bz"))
            {
                return DecompressArchiveBzip2();
            }
            else if (ext.Equals(".gz") || ext.Equals(".gzip"))
            {
                return DecompressArchiveGZip();
            }
            else if (ext.Equals(".tar"))
            {
                return DecompressArchiveTar();
            }
            else
            {
                return null;
            }
        }

        public static bool IsZip(string filepath)
        {            
            string ext = System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".zip",StringComparison.InvariantCultureIgnoreCase)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTar(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".tar", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsGZip(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".gzip", StringComparison.InvariantCultureIgnoreCase)
            || ext.Equals(".gz", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsBzip2(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".bz2", StringComparison.InvariantCultureIgnoreCase)
            || ext.Equals(".bzip2", StringComparison.InvariantCultureIgnoreCase)
            || ext.Equals(".bz", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsRar(string filepath)
        {
            string ext = System.IO.Path.GetExtension(filepath);

            if (ext.Equals(".rar", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomExtractedFilesInfo DecompressArchiveRar()
        {
            Unrar unrar = new Unrar();
            
            try
            {
                GetUncompressedDirectoryPath(Filepath);
                System.IO.Directory.CreateDirectory(UncompressedDirectoryPath);
                List<string> uncompressed_files = new List<string>();

                unrar.MissingVolume += new MissingVolumeHandler(unrar_MissingVolume);
                unrar.PasswordRequired += new PasswordRequiredHandler(unrar_PasswordRequired);

                // Set destination path for all files
                unrar.DestinationPath = UncompressedDirectoryPath;

                // Open archive for extraction
                unrar.Open(Filepath, Unrar.OpenMode.Extract);

                // Extract each file found in hashtable
                
                while (unrar.ReadHeader())
                {
                    if (!unrar.CurrentFile.IsDirectory)
                    {
                        uncompressed_files.Add(UncompressedDirectoryPath + "\\" + unrar.CurrentFile.FileName);
                    }
                    unrar.Extract();

                }

                CustomExtractedFilesInfo cif = new CustomExtractedFilesInfo();
                cif.UncompressedFiles = uncompressed_files;
                cif.UncompressedDirectory = UncompressedDirectoryPath;
                cif.CompressedFilepath = Filepath;

                return cif;

            }
            catch (Exception ex)
            {
                Module.ShowError(ex);

                return null;
            }
            finally
            {
                unrar.Close();
                unrar.Dispose();
            }

        }

        void unrar_PasswordRequired(object sender, PasswordRequiredEventArgs e)
        {
            if (SKIP_ALL_ARCHIVES_WITH_PASSWORDS)
            {
                e.ContinueOperation = false;
                return;
            }

            frmArchivePassword fapa = new frmArchivePassword();
            fapa.txtArchive.Text = Filepath;
            fapa.ShowDialog();

            if (fapa.PressedOK)
            {
                Password = fapa.txtPassword.Text;
                e.Password = fapa.txtPassword.Text;


            }
            else if (fapa.PressedSkip)
            {
                e.ContinueOperation = false;
                return;
            }
            else if (fapa.PressedSkipAll)
            {
                SKIP_ALL_ARCHIVES_WITH_PASSWORDS = true;
                e.ContinueOperation = false;
                return;
            }

        }

        void unrar_MissingVolume(object sender, MissingVolumeEventArgs e)
        {
            e.ContinueOperation = false;
        }

        public string GetUncompressedDirectoryPath(string filepath)
        {            
            int h = 0;
            while (true)
            {
                if (h == 0)
                {
                    UncompressedDirectoryPath = TempDirectoryPath + System.IO.Path.GetFileName(Filepath);
                }
                else
                {
                    UncompressedDirectoryPath = TempDirectoryPath + System.IO.Path.GetFileName(Filepath) + "." + h.ToString();
                }

                if (System.IO.File.Exists(UncompressedDirectoryPath) ||
                    System.IO.Directory.Exists(UncompressedDirectoryPath))
                {
                    h++;
                }
                else
                {
                    break;
                }
            }

            return UncompressedDirectoryPath;
        }

        public static bool CompressDirectoryArchiveZip(string folderPath, string filepath)
        {
            ICSharpCode.SharpZipLib.Zip.FastZip zs = new FastZip();
            zs.CreateZip(filepath, folderPath, true, string.Empty);

            return true;
        }

        public CustomExtractedFilesInfo DecompressArchiveZip()
        {
            ZipInputStream s=null;
            List<string> uncompressed_files = new List<string>();

            bool decompression_succeeded = false;

            GetUncompressedDirectoryPath(Filepath);

            System.IO.Directory.CreateDirectory(UncompressedDirectoryPath);                        

            try
            {
                s = new ZipInputStream(File.OpenRead(Filepath));

                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    decompression_succeeded = false;

                    while (!decompression_succeeded)
                    {
                        if (theEntry.IsCrypted)
                        {
                            if (SKIP_ALL_ARCHIVES_WITH_PASSWORDS) return null;

                            s.Password = Password;

                            frmArchivePassword fapa = new frmArchivePassword();
                            fapa.txtArchive.Text = Filepath;
                            fapa.ShowDialog();

                            if (fapa.PressedOK)
                            {
                                Password = fapa.txtPassword.Text;
                                s.Password = Password;

                            }
                            else if (fapa.PressedSkip)
                            {
                                return null;
                            }
                            else if (fapa.PressedSkipAll)
                            {
                                SKIP_ALL_ARCHIVES_WITH_PASSWORDS = true;
                                return null;
                            }


                        }
                        //Console.WriteLine(theEntry.Name);

                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(UncompressedDirectoryPath+"\\"+directoryName);
                        }

                        if (fileName != String.Empty)
                        {
                            string uncompressed_filepath = UncompressedDirectoryPath + "\\" + theEntry.Name;
                            using (FileStream streamWriter = File.Create(uncompressed_filepath))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {

                                    try
                                    {
                                        size = s.Read(data, 0, data.Length);

                                        if (size > 0)
                                        {
                                            streamWriter.Write(data, 0, size);
                                        }
                                        else
                                        {
                                            decompression_succeeded = true;
                                            uncompressed_files.Add(uncompressed_filepath);
                                            break;
                                        }

                                    }
                                    catch (Exception expassw)
                                    {
                                        if (expassw.Message == "Invalid password")
                                        {
                                            Module.ShowMessage("Invalid Archive Password !");

                                            if (s != null)
                                            {
                                                s.Close();
                                                s.Dispose();
                                                s = new ZipInputStream(File.OpenRead(Filepath));
                                                theEntry = s.GetNextEntry();
                                            }

                                            frmArchivePassword fapa = new frmArchivePassword();
                                            fapa.txtArchive.Text = Filepath;
                                            fapa.ShowDialog();

                                            if (fapa.PressedOK)
                                            {
                                                Password = fapa.txtPassword.Text;
                                                s.Password = Password;

                                            }
                                            else if (fapa.PressedSkip)
                                            {
                                                return null;
                                            }
                                            else if (fapa.PressedSkipAll)
                                            {
                                                SKIP_ALL_ARCHIVES_WITH_PASSWORDS = true;
                                                return null;
                                            }
                                        }
                                        else
                                        {
                                            throw (expassw);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            decompression_succeeded = true;
                        }
                    }
                }

                CustomExtractedFilesInfo cif = new CustomExtractedFilesInfo();
                cif.UncompressedFiles=uncompressed_files;
                cif.UncompressedDirectory = UncompressedDirectoryPath;
                cif.CompressedFilepath = Filepath;

                return cif;
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);               

                return null;
            }
            finally
            {
                if (s != null)
                {
                    try
                    {
                        s.Close();
                        s.Dispose();
                    }
                    catch { }
                }
            }
        }

        public CustomExtractedFilesInfo DecompressArchiveGZip()
        {
            // decompress an archive e.g. ab.doc.gz -> ab.doc
            // one gzip file contains only one archive..

            GZipInputStream s = null;
            List<string> uncompressed_files = new List<string>();                        

            GetUncompressedDirectoryPath(Filepath);

            System.IO.Directory.CreateDirectory(UncompressedDirectoryPath);

            try
            {
                s = new GZipInputStream(File.OpenRead(Filepath));


                string fileName = System.IO.Path.GetFileNameWithoutExtension(Filepath);

                if (fileName != String.Empty)
                {
                    string uncompressed_filepath = UncompressedDirectoryPath + "\\" + fileName;
                    using (FileStream streamWriter = File.Create(uncompressed_filepath))
                    {

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {


                            size = s.Read(data, 0, data.Length);

                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                uncompressed_files.Add(uncompressed_filepath);
                                break;
                            }
                        }
                    }
                }
                
                CustomExtractedFilesInfo cif = new CustomExtractedFilesInfo();
                cif.UncompressedFiles = uncompressed_files;
                cif.UncompressedDirectory = UncompressedDirectoryPath;
                cif.CompressedFilepath = Filepath;

                return cif;
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);

                return null;
            }
            finally
            {
                if (s != null)
                {
                    try
                    {
                        s.Close();
                        s.Dispose();
                    }
                    catch { }
                }
            }
        }

        public CustomExtractedFilesInfo DecompressArchiveBzip2()
        {
            // decompress an archive e.g. ab.doc.gz -> ab.doc
            // one gzip file contains only one archive..

            BZip2InputStream s = null;
            List<string> uncompressed_files = new List<string>();

            GetUncompressedDirectoryPath(Filepath);

            System.IO.Directory.CreateDirectory(UncompressedDirectoryPath);

            try
            {
                s = new BZip2InputStream(File.OpenRead(Filepath));
                
                string fileName = System.IO.Path.GetFileNameWithoutExtension(Filepath);

                if (fileName != String.Empty)
                {
                    string uncompressed_filepath = UncompressedDirectoryPath + "\\" + fileName;
                    using (FileStream streamWriter = File.Create(uncompressed_filepath))
                    {

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {


                            size = s.Read(data, 0, data.Length);

                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                uncompressed_files.Add(uncompressed_filepath);
                                break;
                            }
                        }
                    }
                }

                CustomExtractedFilesInfo cif = new CustomExtractedFilesInfo();
                cif.UncompressedFiles = uncompressed_files;
                cif.UncompressedDirectory = UncompressedDirectoryPath;
                cif.CompressedFilepath = Filepath;

                return cif;
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);

                return null;
            }
            finally
            {
                if (s != null)
                {
                    try
                    {
                        s.Close();
                        s.Dispose();
                    }
                    catch { }
                }
            }
        }

        public CustomExtractedFilesInfo DecompressArchiveTar()
        {
            TarArchive tar_archive = null;

            // decompress an archive e.g. ab.doc.gz -> ab.doc
            // one gzip file contains only one archive..

            List<string> uncompressed_files = new List<string>();                        

            GetUncompressedDirectoryPath(Filepath);

            System.IO.Directory.CreateDirectory(UncompressedDirectoryPath);

            try
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(Filepath);

                if (fileName != String.Empty)
                {
                    string uncompressed_filepath = UncompressedDirectoryPath + "\\" + fileName;
                    tar_archive = TarArchive.CreateInputTarArchive(File.OpenRead(Filepath));
                    tar_archive.ExtractContents(UncompressedDirectoryPath);

                    GetDirectoryFiles(UncompressedDirectoryPath, uncompressed_files);                    

                }
                
                CustomExtractedFilesInfo cif = new CustomExtractedFilesInfo();
                cif.UncompressedFiles = uncompressed_files;
                cif.UncompressedDirectory = UncompressedDirectoryPath;
                cif.CompressedFilepath = Filepath;

                return cif;
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);

                return null;
            }
            finally
            {               
                if (tar_archive != null)
                {
                    try
                    {
                        tar_archive.Close();
                       //1 ? tar_archive.Dispose();
                    }
                    catch { }
                }
            }
        }

        private static void GetDirectoryFiles(string dir, List<string> uncompressed_files)
        {
            string[] filez = System.IO.Directory.GetFiles(dir);
            for (int k = 0; k < filez.Length; k++)
            {
                if (System.IO.Directory.Exists(filez[k]))
                {
                    GetDirectoryFiles(filez[k], uncompressed_files);
                }
                else
                {
                    uncompressed_files.Add(filez[k]);
                }
            }
        }

        public static string GetUnCompressedFileName(string uncompressed_filepath,
            string compressed_filepath)
        {
            string first = uncompressed_filepath.Substring(TempDirectoryPath.Length);
            int spos = first.IndexOf("\\");
            first = first.Substring(spos);
            first = System.IO.Path.GetFileName(compressed_filepath) + first;

            return first;
        }
    }

    public class CustomExtractedFilesInfo
    {
        public List<string> UncompressedFiles = null;
        public string CompressedFilepath = "";
        public string UncompressedDirectory = "";
    }
}