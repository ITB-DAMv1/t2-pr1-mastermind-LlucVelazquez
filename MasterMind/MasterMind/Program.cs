using System;
public class Program
{
    private static void Main()
    {
        const string Title = " __  __    _    ___  _____  ___  ___  __  __  ___  _  _  ___" +
            "\n|  \\/  |  /_\\  / __||_   _|| __|| _ \\|  \\/  ||_ _|| \\| ||   \\" +
            "\n| |\\/| | / _ \\ \\__ \\  | |  | _| |   /| |\\/| | | | | .` || |) |" +
            "\n|_|  |_|/_/ \\_\\|___/  |_|  |___||_|_\\|_|  |_||___||_|\\_||___/\n";
        const string Title2 = "per: Lluc Velazquez\n";
        const string Objetive = "L'objectiu d'aquest joc es que l'usuari ha d'endevinar la combinacio secreta de 4 numeros entre el numero 1 i 6 en el menor d'intents possibles" +
            "\nEscull la dificultat i adivina el numero sense sobrepassar els intents." +
            "\n\nEls numeros es tenen que posar un per un!!! " +
            "\nQualsevol altre numero o caracter que no sigui entre el 1 i el 6 comptara com intent!!!" +
            "\n\nBona sort! ^_^\n";
        const string Difficult = "Escull quina dificultat vols, tens que posar el numero de la dificulat\n1. Dificultat novell: 10 intents \n2. Dificultat aficionat: 6 intents " +
            "\n3. Dificultat expert: 4 intents \n4. Dificultat Màster: 3 intents \n5. Dificultat personalitzada ";
        const string Text = "Posa el numero";
        const string Help = "Pista: ";
        const string ErrorEnter = "S'espera un nombre enter";
        const string TextAttemps = "Quants intents vols? ";
        const string IncorrectNum = "Numero incorrecte";
        const string Enter = "Prem Enter per finalitzar: ";
        const string Winner = "Has guanyat!";
        const string Loser = "Has Perdut\nLa combinacio secreta es:";
        const string Error = "Posa un numero entre el 1 i el 6! >:(";
        const char PositionPerf = 'O';
        const char PositionNear = 'Ø';
        const char PositionWrong = '×';
        string answer = "";
        int numDifficult = 0; // per saber quina dificultat escull
        int maxAttempts = 0; // maxim intents que tindra el usuari
        int attempts = 0; // intents del usuari
        bool winCondition = false; // boolea per saber si ha guanyat o no
        int perfect = 0; // quantitat de nombres acertats en un intent
        const int Size = 4; // mida de la array
        int[] solution = { 4, 3, 1, 5 }; // Solucio del MasterMind
        int[] userNum = new int[Size]; // Array on es posara el resultat del usuari

        /* Aqui sortira el titol amb les dificultats possibles, amb un try/catch per si el que posa no es un numero, 
         * despres ademes hi ha un do while que si el numero es mes petit o igual a 0 o si es mes gran o igual a 6 estara en el bucle fins que no posi un numero diferent.
         * En el switch, depenent del que hagi posat es fara un cas o un altre. */
        do
        {
            try
            {
                Console.WriteLine(Title);
                Console.WriteLine(Title2);
                Console.WriteLine(Objetive);
                Console.WriteLine(Difficult);
                numDifficult = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(ErrorEnter);
            }
        } while (numDifficult <= 0 || numDifficult >= 6);
        switch (numDifficult)
        {
            case 1:
                maxAttempts = 10;
                break;
            case 2:
                maxAttempts = 6;
                break;
            case 3:
                maxAttempts = 4;
                break;
            case 4:
                maxAttempts = 3;
                break;
            case 5:
                Console.WriteLine(TextAttemps);
                maxAttempts = int.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine(IncorrectNum);
                break;

        }
        /* Ara la part del mastermind, en aquest while sera per els intents i si ha guanyat, el maxAttemps seran els intents que abrem escollit abans.
         * despres farem que perfect sigui 0 (aixo perque es reinici cada cop)
         * ara un for per demanar un numero per a la array del resultat del usuari, que aixo estara disn de un try/catch per si no posa un numero,
         * si no posa un numero, sortira el missatge d'error pero comptara com intent ya que ya sabia avisat de que te que ser un valor entre el 1 i el 6.*/
        while (attempts < maxAttempts && !winCondition)
        {
            perfect = 0;
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine(Text);
                try
                {
                    userNum[i] = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(Error);
                }
                /* en aquest if sera per si aques num en la posicio "i" esta en la solucio,
                 * si esta, es sabra amb el seguent if que comproba el numero si esta en la meteixa posicio que en la solucio,
                 * si esta sumara a perfect un +1 i en answer posara el caracter de perfecte "O"
                 * si no esta es fara lo del dins del else, es posara en answer el caracter que esta pero en la posicio correcte "Ø"
                 * si no esta ni en la solucio, fara el else i posara la resposta de wrong incorrecte "×"
                 * aixo es repetira 4 cops 
                 * si s'ha adivinat el nombre en la posicio correcte en el amateix intents ( o sigui els 4 numeros) perfect sera 4 i win condition sera true per poder sortir del while,
                 * pero abams posant el resultat i sumant un intent
                 * si no ha adivinat el numero seguira en el bucle finbs que no ho acerti o es pasi d'intents.*/
                if (solution.Contains(userNum[i]))
                {
                    if (userNum[i] == solution[i])
                    {
                        perfect++;
                        answer = String.Concat(answer, PositionPerf);
                    }
                    else
                    {
                        answer = String.Concat(answer, PositionNear);
                    }
                    if (perfect == 4)
                    {
                        winCondition = true;
                    }
                }
                else
                {
                    answer = String.Concat(answer, PositionWrong);
                }

            }
            Console.Write(Help);
            Console.WriteLine(answer);
            answer = "";
            attempts = attempts + 1;
            /* Ara amb aquest if sabrem perque ha sortit del bucle, si es per la win condition, vol dir que ha guanyat
             * pero si ha sortit del bucle per els intents vol dir que ha sortit per que s'ha pasat d'intents iha perdut 
             * fem un writeline de que premi enter per soritr i acabara el nostre programa */
        }
        if (winCondition)
        {
            Console.WriteLine(Winner);
        }
        else
        {
            Console.WriteLine($"{Loser} {solution[0]} {solution[1]} {solution[2]} {solution[3]}");
        }
        Console.WriteLine(Enter);
        Console.ReadLine();
    }
}
