namespace AdventOfCode;

public class Day02 : BaseDay {
    private readonly string _input;
    enum RPS { Rock, Paper, Scissors};
    string[] games;



    public Day02() {
        _input = File.ReadAllText(InputFilePath);
        games = _input.Split(Environment.NewLine, System.StringSplitOptions.RemoveEmptyEntries);
    }

    public override ValueTask<string> Solve_1() {
        RPS elfChoice;
        RPS playerChoice;
        int playerScore = 0;
        int tempPlayerScore = 0;
        foreach (var game in games) {
            elfChoice = game[0] switch {
                'A' => RPS.Rock,
                'B' => RPS.Paper,
                'C' => RPS.Scissors
            };
            switch(game[2]){

                case 'X':
                    playerChoice = RPS.Rock;
                    tempPlayerScore = 1;
                    break;
                case 'Y':
                    playerChoice = RPS.Paper;
                    tempPlayerScore = 2;
                    break;
                case 'Z':
                    playerChoice = RPS.Scissors;
                    tempPlayerScore = 3;
                    break;
                default:
                    playerChoice = RPS.Rock;
                    break;
            }
            if (playerChoice == elfChoice) {
                tempPlayerScore += 3;
            } else {
                if (playerChoice == RPS.Rock && elfChoice == RPS.Scissors) {
                    tempPlayerScore += 6;
                } else if (playerChoice == RPS.Paper && elfChoice == RPS.Rock) {
                    tempPlayerScore += 6;
            } else if (playerChoice == RPS.Scissors && elfChoice == RPS.Paper) {
                    tempPlayerScore += 6;
            }
            }
            playerScore += tempPlayerScore;
        }

        
        

        return new ValueTask<string>(playerScore.ToString());
    }

    public override ValueTask<string> Solve_2() {
        RPS elfChoice;
        RPS playerChoice;
        int playerScore = 0;
        int tempPlayerScore = 0;
        foreach (var game in games) {
            elfChoice = game[0] switch {
                'A' => RPS.Rock,
                'B' => RPS.Paper,
                'C' => RPS.Scissors
            };
            switch (game[2]) {

                case 'X':
                    tempPlayerScore = 0;
                    if (elfChoice == RPS.Rock) {
                        tempPlayerScore += 3;
                    } else if (elfChoice == RPS.Paper) {
                        tempPlayerScore += 1;
                    } else if (elfChoice == RPS.Scissors) {
                        tempPlayerScore += 2;
                    }
                    break;
                case 'Y':
                    tempPlayerScore = 3;
                    if (elfChoice == RPS.Rock) {
                        tempPlayerScore += 1;
                    } else if (elfChoice == RPS.Paper) {
                        tempPlayerScore += 2;
                    } else if (elfChoice == RPS.Scissors) {
                        tempPlayerScore += 3;
                    }
                    break;
                case 'Z':
                    tempPlayerScore = 6;
                    if (elfChoice == RPS.Rock) {
                        tempPlayerScore += 2;
                    } else if (elfChoice == RPS.Paper) {
                        tempPlayerScore += 3;
                    } else if (elfChoice == RPS.Scissors) {
                        tempPlayerScore += 1;
                    }
                    break;
                default:
                    break;
            }
           
            
            playerScore += tempPlayerScore;
        }




        return new ValueTask<string>(playerScore.ToString());
    }
}
