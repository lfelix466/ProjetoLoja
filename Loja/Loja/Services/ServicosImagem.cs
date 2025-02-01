using Loja.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Loja.Services
{
    public class ServicosImagem
    {

        public async Task<byte[]?> converteImagem(IFormFile imagem)
        {
            if (imagem != null && imagem.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagem.CopyToAsync(memoryStream);
                    return memoryStream.ToArray(); // Store the image as byte array
                }
            }
            return null;
        }
    }
}
