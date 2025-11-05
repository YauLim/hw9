public class TV
{
    public void On()
    {
        Console.WriteLine("Телевизор включен");
    }
    public void Off()
    {
        Console.WriteLine("Телевизор выключен");
    }
    public void SelectChannel(int channel)
    {
        Console.WriteLine($"Телевизор: выбран канал {channel}");
    }
    public void SetAudioInput()
    {
        Console.WriteLine("Телевизор: установлен аудиовход для прослушивания музыки");
    }
}

public class AudioSystem
{
    public void On()
    {
        Console.WriteLine("Аудиосистема включена");
    }
    public void Off()
    {
        Console.WriteLine("Аудиосистема выключена");
    }
    public void SetVolume(int volume)
    {
        Console.WriteLine($"Аудиосистема: громкость установлена на {volume}");
    }
}

public class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVD-проигрыватель: воспроизведение");
    }
    public void Pause()
    {
        Console.WriteLine("DVD-проигрыватель: пауза");
    }
    public void Stop()
    {
        Console.WriteLine("DVD-проигрыватель: остановка");
    }
}

public class GameConsole
{
    public void On()
    {
        Console.WriteLine("Игровая консоль включена");
    }
    public void Off()
    {
        Console.WriteLine("Игровая консоль выключена");
    }
    public void StartGame()
    {
        Console.WriteLine("Игровая консоль: игра запущена");
    }
}

public class HomeTheaterFacade
{
    private readonly TV _tv;
    private readonly AudioSystem _audioSystem;
    private readonly DVDPlayer _dvdPlayer;
    private readonly GameConsole _gameConsole;

    public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdPlayer, GameConsole gameConsole)
    {
        _tv = tv;
        _audioSystem = audioSystem;
        _dvdPlayer = dvdPlayer;
        _gameConsole = gameConsole;
    }

    public void WatchMovie()
    {
        _tv.On();
        _tv.SelectChannel(5); 
        _audioSystem.On();
        _audioSystem.SetVolume(15);
        _dvdPlayer.Play();
    }
    
    public void TurnEverythingOff()
    {
        _dvdPlayer.Stop();
        _gameConsole.Off();
        _audioSystem.Off();
        _tv.Off();
    }
    
    public void StartGaming()
    {
        _tv.On();
        _tv.SelectChannel(3); 
        _audioSystem.On();
        _audioSystem.SetVolume(20);
        _gameConsole.On();
        _gameConsole.StartGame();
    }
    
    public void ListenToMusic()
    {
        _audioSystem.On();
        _audioSystem.SetVolume(25);
        _tv.On(); 
        _tv.SetAudioInput();
    }
    
    public void AdjustVolume(int volume)
    {
        _audioSystem.SetVolume(volume);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var tv = new TV();
        var audioSystem = new AudioSystem();
        var dvdPlayer = new DVDPlayer();
        var gameConsole = new GameConsole();
        var homeTheater = new HomeTheaterFacade(tv, audioSystem, dvdPlayer, gameConsole);
        
        homeTheater.WatchMovie();
        homeTheater.TurnEverythingOff();
        homeTheater.StartGaming();
        homeTheater.AdjustVolume(20);
        homeTheater.ListenToMusic();
        homeTheater.TurnEverythingOff();
    }
}