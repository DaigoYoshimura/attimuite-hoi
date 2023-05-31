using System;

//じゃんけんパート
public enum Hand
{
    Rock,
    Paper,
    Scissors
}

//あっちむいてほいパート
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Player
{
    public Hand SelectedHand { get; set; }
    public Direction SelectedDirection { get; set; }
}

public class Game
{
    private Player player1;　
    private Player player2;

    public Game()
    {
        player1 = new Player();
        player2 = new Player();
    }

    public void PlayJanken()
    {
        while (true)
        {
            player1.SelectedHand = GetPlayerHand("プレイヤー1"); 
            player2.SelectedHand = GetPlayerHand("プレイヤー2");
            Console.WriteLine("プレイヤー1の選択: " + player1.SelectedHand);
            Console.WriteLine("プレイヤー2の選択: " + player2.SelectedHand);
            if(player1.SelectedHand == player2.SelectedHand)
            {
                Console.WriteLine("あいこ！もういちど");
                continue; // あいこの場合もう一度実行する
            }
            break;
        }
        
    }

    public void PlayAchiMuiteHoi()
    {
            player1.SelectedDirection = GetPlayerDirection("プレイヤー1");
            player2.SelectedDirection = GetPlayerDirection("プレイヤー2");

            Console.WriteLine("プレイヤー1の選択: " + player1.SelectedDirection);
            Console.WriteLine("プレイヤー2の選択: " + player2.SelectedDirection);
            if (player1.SelectedDirection != player2.SelectedDirection)
            {
               return;
            }
    }

    private Hand GetPlayerHand(string playerName)
    {
        Console.WriteLine(playerName + "の手を選んでください (0 - グー, 1 - パー, 2 - チョキ): ");
        int handInput = Convert.ToInt32(Console.ReadLine());

        if (handInput >= 0 && handInput <= 2)
        {
            return (Hand)handInput;
        }
        else
        {
            Console.WriteLine("エラー。もう一度試してください。");
            return GetPlayerHand(playerName);
        }
    }

    private Direction GetPlayerDirection(string playerName)
    {
        Console.WriteLine(playerName + "の方向を選んでください (0 - 上, 1 - 下, 2 - 左, 3 - 右): ");
        int directionInput = Convert.ToInt32(Console.ReadLine());

        if (directionInput >= 0 && directionInput <= 3)
        {
            return (Direction)directionInput;
        }
        else
        {
            Console.WriteLine("エラー。もう一度試してください。");
            return GetPlayerDirection(playerName);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.PlayJanken();
        game.PlayAchiMuiteHoi();
    }
}
