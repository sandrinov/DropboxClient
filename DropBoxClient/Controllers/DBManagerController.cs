using Dropbox.Api;
using Dropbox.Api.Files;
using DropBoxClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DropBoxClient.Controllers
{
    public class DBManagerController : Controller
    {
        private string accessToken = "";
        // GET: DBManager
        public async Task<ActionResult> Index()
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                ViewBag.dbUser = full.Name.DisplayName + " " + full.Email;
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(enableValidation: false)]
        public async Task<ActionResult> NewDirectory(string dirname)
        {
            List<DirViewModel> resultList = new List<DirViewModel>();
            using (var dbx = new DropboxClient(accessToken))
            {
                var folderArg = new CreateFolderArg(dirname);
                var result = await dbx.Files.CreateFolderV2Async(folderArg);

                var listResult = await dbx.Files.ListFolderAsync(string.Empty);
                // show folders
                foreach (var item in listResult.Entries.Where(i => i.IsFolder))
                {
                    resultList.Add(new DirViewModel() { Path = item.PathDisplay, Name = item.Name });
                }
            }
            return View(resultList);
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(enableValidation: false)]
        public async Task<ActionResult> UploadFile(FileUploadViewModel model)
        {
            List<FileViewModel> resultList = new List<FileViewModel>();

            if (ModelState.IsValid)
            {
                // Use your file here
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //model.File.InputStream.CopyTo(memoryStream);
                    using (var dbx = new DropboxClient(accessToken))
                    {
                        var updated = await dbx.Files.UploadAsync(
                            model.Dir + "/" + model.File.FileName,
                            WriteMode.Overwrite.Instance,
                             body: model.File.InputStream);
                        // body: memoryStream);
                        ListFolderArg arg = new ListFolderArg(model.Dir);
                        var listFolderResult = await dbx.Files.ListFolderAsync(arg);

                        foreach (var item in listFolderResult.Entries.Where(i => i.IsFile))
                        {
                            resultList.Add(new FileViewModel() { Name = item.Name, Size = item.AsFile.Size, LastUpdate=item.AsFile.ServerModified.ToLongDateString() });
                        }
                    }
                }
            }
            return View(resultList);
        }
    }
}