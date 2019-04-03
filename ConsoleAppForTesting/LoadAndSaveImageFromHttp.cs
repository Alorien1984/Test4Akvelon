namespace MultiThreading
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>Loads and saves images from current url to current path.</summary>
    class LoadAndSaveImageFromHttp
    {
        /// <summary>The web client.</summary>
        private WebClient webClient;
        /// <summary>Gets or sets the collection of image data.</summary>
        /// <value>The collection of image data.</value>
        public BlockingCollection<byte[]> ImageData { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="LoadAndSaveImageFromHttp"/> class.</summary>
        public LoadAndSaveImageFromHttp()
        {
            ImageData = new BlockingCollection<byte[]>();
            webClient = new WebClient();
        }

        /// <summary>Loads the image by path.</summary>
        /// <param name="indexOfImage">The index of image.</param>
        /// <param name="pathToImage">The path to image.</param>
        /// <returns>Index of uploaded image</returns>
        public async Task<int> LoadImageByPath(string indexOfImage,
                        string pathToImage = @"https://image.tmdb.org/t/p/w1280/c9HBH0D1YiX2PVczZihBnCUWsaU.jpg")
        {
            byte[] item;
            Console.WriteLine("Entered");

            using (webClient)
            {
                item = await webClient.DownloadDataTaskAsync(new Uri(pathToImage)).ConfigureAwait(false); 
            }

            var success = false;

            if (item != null)
            {
                Console.WriteLine($"File {indexOfImage} was downloaded");
                while (!success)
                {
                    try
                    {
                        success = ImageData.TryAdd(item, 2);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine($"Add loop was canceled: {ex}");
                        ImageData.CompleteAdding();
                        break;
                    }
                }
                
                Console.WriteLine("File has been uploaded");
                return Convert.ToInt32(indexOfImage);
            }
            Console.WriteLine("Image hasn't been uploaded.");
            return -1;
        }

        /// <summary>Saves the images by path.</summary>
        /// <param name="images">The images.</param>
        /// <param name="pathToSaveImage">The path to save image.</param>
        public async Task SaveImagesByPath(BlockingCollection<byte[]> images,
            string pathToSaveImage = @"C:\Users\v-mamoc\Downloads\books\")
        {
            var index = 0;
            if (images.Any())
            {
                foreach (var image in images)
                {
                    var path = Path.Combine(pathToSaveImage, $"image#{index}.jpg");
                    await File.WriteAllBytesAsync(path, image);
                    Console.WriteLine($"File {index} has been saved");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Collection must not be empty");
            }

        }

        public async Task ClearAllImages()
        {
            if (ImageData.IsAddingCompleted)
            {
                await Task.Factory.StartNew(() =>
                {
                    foreach (var image in ImageData.GetConsumingEnumerable())
                    {
                        Console.WriteLine($"Element has been removed. Count of collection: {ImageData.Count}");
                    }
                });
            }
            else
            {
                Console.WriteLine("Collection not ready to be empty");
            }
        }
    }
}
