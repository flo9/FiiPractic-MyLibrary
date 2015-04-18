using MyLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceClient
{
    public class BookService : IBookService
    {
        string url;
        HttpClient client; 
        public BookService( string url)
        {
            this.url = url;
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public Book FindBookById(int? id)
        {
            var bookUrl = String.Format("book/{1}", url, id);

            var model = client
                   .GetAsync(bookUrl)
                   .Result
                   .Content.ReadAsAsync<Book>().Result;

            return model;
        }

        public IEnumerable<Book> List(string bookGenre, string filterByTitle)
        {
            var bookUrl = String.Format("book/", url);

            var model = client
                   .GetAsync(bookUrl)
                   .Result
                   .Content.ReadAsAsync<IEnumerable<Book>>().Result;
                   

            return model;
        }

        public IEnumerable<string> Genres()
        {
            var bookUrl = String.Format("book/Genres", url);

            var model = client
                   .GetAsync(bookUrl)
                   .Result
                   .Content.ReadAsAsync<IEnumerable<string>>().Result;
            

            return model; 
        }

        public bool Add(Book book)
        {
            var bookUrl = String.Format("book/", url);
            bool rep = false;
            using (var response = client
                   .PostAsJsonAsync(bookUrl, book)
                   .Result)
            {
                rep= response.IsSuccessStatusCode;
                
            }

            return rep;
        }

        public bool Update(Book book)
        {
            var bookUrl = String.Format("book/{0}/", book.ID);

            using (var response = client
                   .PutAsJsonAsync(bookUrl, book)
                   .Result)
            {
                return response.IsSuccessStatusCode;

            }

            return false;
        }

        public bool Delete(int id)
        {
            var bookUrl = String.Format("book/{0}/",id);

            using (var response = client
                   .DeleteAsync(bookUrl)
                   .Result)
            {
                return response.IsSuccessStatusCode;

            }

            return false;
        }
    }
}
