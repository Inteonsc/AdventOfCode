namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    string[] elves;
    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        elves = _input.Split(Environment.NewLine + Environment.NewLine);
    }

    public override ValueTask<string> Solve_1() {
       
        int highestCalories = 0;


        foreach (string elf in elves) {
            string[] snacklist = elf.Split(Environment.NewLine,StringSplitOptions.RemoveEmptyEntries);
            int calorieCount = 0;
            for (int i = 0; i < snacklist.Length; i++) {
                calorieCount += int.Parse(snacklist[i]);
            }
            highestCalories = calorieCount > highestCalories ? calorieCount : highestCalories ;

        }
        
        return new ValueTask<string>(highestCalories.ToString()); 
    }
    

    public override ValueTask<string> Solve_2() {

        int elf1 = 0;
        int elf2 = 0;
        int elf3 = 0;

        foreach (string elf in elves) {
            string[] snacklist = elf.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int calorieCount = 0;
            for (int i = 0; i < snacklist.Length; i++) {
                calorieCount += int.Parse(snacklist[i]);
            }
            if (calorieCount > elf1) {
                elf3 = elf2;
                elf2 = elf1;
                elf1 = calorieCount;
            } else if (calorieCount > elf2) {
                elf3 = elf2;
                elf2 = calorieCount;
            } else if (calorieCount > elf3) {
                elf3 = calorieCount;
            }

        }
        int totalCalories = elf1 + elf2 + elf3;
        return new ValueTask<string>(totalCalories.ToString());
    }
}
