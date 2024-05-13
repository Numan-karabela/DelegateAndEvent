string path = @"";
PathControl pathControl = new();


pathControl.pathHnadlerevent += (SizeMb) =>
{
    Console.WriteLine("Boyut 50 Mb geçmiştir ");
};
await pathControl.Controll(path);


class PathControl
{
    public delegate void PathHandler(long SizeMb);
    public event PathHandler pathHnadlerevent;

    public async Task Controll(string path)
    {
        while (true)
        {

            await Task.Delay(1500);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var file = directoryInfo.GetFiles();
            var size = await Task.Run(() => directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length));
            var sizeMb = (size / 1024) / 1024;
            if (sizeMb > 50)
            {
                pathHnadlerevent(sizeMb);
            }

        }



    }


}