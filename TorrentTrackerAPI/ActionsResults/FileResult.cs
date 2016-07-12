using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace TorrentTrackerAPI.ActionsResults
{
    public class FileResult : IHttpActionResult
    {
        private byte[] _fileContent;
        private string _FileName;
        public FileResult(byte[] fileContent, string filename)
        {
            _fileContent = fileContent;
            _FileName = filename;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new MemoryStream(_fileContent));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            response.Content.Headers.ContentDisposition.FileName = _FileName;

            return Task.FromResult(response);
        }
    }
}