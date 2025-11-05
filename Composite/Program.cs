public abstract class FileSystemComponent
{
    public string _name;
    public FileSystemComponent(string name)
    {
        _name = name;
    }
    public abstract void Display(int depth);
    public abstract long GetSize();
}

public class File : FileSystemComponent
{
    private readonly long _size;
    public File(string name, long size) : base(name)
    {
        _size = size;
    }
    public override void Display(int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}- Файл: {_name} (Размер: {_size} байт)");
    }
    public override long GetSize()
    {
        return _size;
    }
}

public class Directory : FileSystemComponent
{
    private readonly List<FileSystemComponent> _children = new List<FileSystemComponent>();
    public Directory(string name) : base(name) { }
    public void AddComponent(FileSystemComponent component)
    {
        if (!_children.Contains(component))
        {
            _children.Add(component);
        }
        else
        {
            Console.WriteLine($"Компонент '{component._name}' уже существует в папке '{_name}'.");
        }
    }

    public void RemoveComponent(FileSystemComponent component)
    {
        if (_children.Contains(component))
        {
             _children.Remove(component);
        }
        else
        {
            Console.WriteLine($"Компонент '{component._name}' не найден в папке '{_name}'.");
        }
    }

    public override void Display(int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}+ Папка: {_name} (Общий размер: {GetSize()} байт)");

        foreach (var component in _children)
        {
            component.Display(depth + 1);
        }
    }

    public override long GetSize()
    {
        return _children.Sum(component => component.GetSize());
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var root = new Directory("Диск C");
        var documents = new Directory("Документы");
        var music = new Directory("Музыка");
        var systemFiles = new Directory("System");
        var report = new File("Отчет.docx", 1234); 
        var presentation = new File("Презентация.pptx", 2345); 
        var song1 = new File("track01.mp3", 3456); 
        var systemKernel = new File("kernel32.dll", 4567); 

        root.AddComponent(documents);
        root.AddComponent(music);
        root.AddComponent(systemFiles);
        documents.AddComponent(report);
        documents.AddComponent(presentation);
        music.AddComponent(song1);
        
        var rockMusic = new Directory("Rock");
        var song2 = new File("music.mp3", 5678); 
        rockMusic.AddComponent(song2);
        music.AddComponent(rockMusic);
        systemFiles.AddComponent(systemKernel);
        root.Display(0);

        Console.WriteLine($"Общий размер 'Диска C': {root.GetSize()} байт");
        Console.WriteLine($"Общий размер папки 'Документы': {documents.GetSize()} байт");
        Console.WriteLine($"Общий размер папки 'Музыка': {music.GetSize()} байт");
        Console.WriteLine("Попытка добавить 'Отчет_2024.docx' в 'Документы' еще раз:");
        documents.AddComponent(report);
        documents.RemoveComponent(presentation);
        documents.Display(0);
    }
}