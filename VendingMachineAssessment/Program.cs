 using System;
 using System.Threading;//this will allow for delaying the code execution later on

namespace VendingMachineAssessment
{
    class Program
    {
     
        static void Main(string[] args)
        {
            //Variables---------------------------------------------------------------------------
            int index = 0;//the index is used for retrieving the correct data from the two arrays
            string[] productNames = new string[5] { "Chocolate Bar", "Soda Can", "Soda Bottle", "Crisps", "Cookies" };
            decimal[] productCost = new decimal[5] { 0.80M, 0.70M, 1.25M, 0.50M, 1.10M };
            string[] menuSpacing = new string[5] { "    ", "         ", "      ", "           ", "          " };
            decimal totalCredits = 0.00M;
            decimal creditInsert = 0.00M;
            bool exitProgram = false;
            bool menuSelectionValid = false;
            int menuSelection;
            bool isNumber;
            string addAnotherItem;
            bool selectedItem = false;
            int itemSelected;
            decimal subTotal = 0.00M;
            string insufficientFunds;
            //Main code-------------------------------------------------------------------------
            while (exitProgram == false)//start of the programs main loop
            {
                Console.Write(@"
 -----------------------------------------
 The Vending Machine Corp
                            by Connor Page
 -----------------------------------------
 Main Menu:
 1. Insert Credits (Current credits = {0})
 2. Product\s Selection
 3. Exit Program", totalCredits);//the string does not use the same indentation as the rest of the code so that it starts on the left side when running
                Console.WriteLine("");
                menuSelectionValid = false;// this is set to false to allow the next while loop to run through at least one iteration
                while (menuSelectionValid == false)// the while loop will run as long as menuSelectionValid is false
                {
                    Console.Write("Please enter a number:");
                    isNumber = int.TryParse(Console.ReadLine(),out menuSelection);//this will attempt to parse the string into an integer if it does then it will set the value of menuSelection, if not then it will execute the else in the if statement
                    if (menuSelection == 1)//checks if the value of menuSelection is equal to 1
                    {// Insert Credits-----------------------------------------------------------------------------------------------------------------------------
                        menuSelectionValid = true;//this will exit the validation loop once the insert credits code is finished 
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Add Credits        [Current Balance {0}]", totalCredits);
                        do//this will loop so that there is a valid input for add credits
                        {
                            Console.WriteLine("Please enter the amount of credits that you would like to add");
                            isNumber = decimal.TryParse(Console.ReadLine(), out creditInsert);//this checks if the input is a decimal
                            if (isNumber == false)//if its not decimal than it will output an error message
                            {
                                Console.WriteLine("ERROR: insert a number");
                            }
                            else//if the user input is a decimal than it will output the following messages and exit the loop
                            {
                                Console.WriteLine("Successfully added to total credits");
                                Console.WriteLine("Returning to main menu");
                                Console.WriteLine("----------------------------------------------");
                                Thread.Sleep(2000);//this pauses the code for 2 seconds
                            }
                        } while (isNumber == false);//this will check if the users input wasnt valid if its false then it starts the next iteration of the loop
                        totalCredits = totalCredits + creditInsert;// adds the inserted credits to totalCredits

                    }

                    else if (menuSelection == 2)//Checks if the value of menuSelection is equal to 2
                    {//Order Selection------------------------------------------------------------------------------------------------------------------------------
                        menuSelectionValid = true;

                        Console.WriteLine("Product Selection        [Current Balance {0}]", totalCredits);
                        do//Order selection loop
                        {
                            do
                            {
                                Console.WriteLine("Please select an item from the following list");
                                for (index = 0; index < 5; index++)
                                {
                                    Console.WriteLine("{0}   {1}{2}Credits:{3}", index + 1, productNames[index], menuSpacing[index], productCost[index]);//eg: 1    chocolate bar     Credits:0.80
                                }
                                Console.WriteLine();//creates a new line
                                Console.Write("Please enter the number of the item you have chosen");
                                isNumber = int.TryParse(Console.ReadLine(), out itemSelected);
                                if (itemSelected <1 && itemSelected >5 && isNumber == false)//checks if the users input is lower than 1 and higher than 5 and is a number
                                {
                                    selectedItem = false;//this will keep the user in the loop
                                    Console.WriteLine("ERROR: Please enter a valid number");
                                }
                                else
                                {
                                    index = itemSelected - 1;//this will make 1 for example be 0
                                    subTotal = subTotal + productCost[index];//adds the cost of the item to the subTotal
                                    Console.WriteLine("You have added {0} to your basket, Credit subtotal:{1}",productNames[index], subTotal);
                                    selectedItem = true;
                                }
                            } while (selectedItem == false);//if selectedItem == false then it will start the next iteration
                            
                            do//select another item loop----------------------------------------------------------------------------------------------------------
                            {
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine();//starts a new line
                                Console.Write("Would you like to add another item, enter y(yes) or n(no):");
                                addAnotherItem = Console.ReadLine();
                                if (addAnotherItem != "y" && addAnotherItem != "n")//if "y" or "n" hant been inputted then it will display an error message
                                {
                                    Console.WriteLine("ERROR: please input either 'y' or 'n'");
                                }
                            } while (addAnotherItem != "y" && addAnotherItem != "n");// checks if the user hasnt inputted "y"or"n", if they havent then it will start the next iteration of the slect another item loop
                            Console.WriteLine("----------------------------------------------");
                        } while (addAnotherItem == "y");//checks if addAnotherItem is equal to "y", if it is than it will start the next iteration of the slection loop
                       
                        Console.WriteLine("Starting Payment");
                        Thread.Sleep(2000);//this will pause the execution of the code for 2 seconds
                                           //Payment----------------------------------------------------------------------------------------------------------------------------------
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Payment:");
                        Console.WriteLine("Available Balance: {0}", totalCredits);
                        Console.WriteLine("The Grand total: {0}",subTotal);
                        if ( subTotal > totalCredits)// checks to see if the subTotal is higher than the available credits
                        {
                            Console.WriteLine("Insufficient Credits!!!");
                            Console.WriteLine();
                            do//starts a loop to check if the user input is valid
                            {
                                Console.Write("Would you like to enter any more credits, enter y for yes and n for no:");
                                insufficientFunds = Console.ReadLine();
                                if( insufficientFunds != "y" && insufficientFunds != "n")//if the user didnt enter a valid input then the code below is executed
                                {
                                    Console.WriteLine("ERROR: please enter either y or n");
                                }
                            } while (insufficientFunds != "y" && insufficientFunds != "n");//if the input isnt valid it starts the next iteration
                            if( insufficientFunds == "y")
                            {
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Add More Credits        [Current Balance {0}]", totalCredits);
                                do//this will loop so that there is a valid input for add credits
                                {
                                    Console.WriteLine("Current price difference: {0}", subTotal - totalCredits);
                                    Console.WriteLine("Please enter the remaining credits:");
                                    isNumber = decimal.TryParse(Console.ReadLine(), out creditInsert);//this checks if the input is a decimal
                                    if (isNumber == false)//if its not decimal than it will output an error message
                                    {
                                        Console.WriteLine("ERROR: insert a number");
                                    }
                                    else//if the user input is a decimal than it will output the following messages and exit the loop
                                    {
                                        Console.WriteLine("Successfully added to total credits");
                                        totalCredits = totalCredits + creditInsert;
                                        Console.WriteLine("----------------------------------------------");
                                        Thread.Sleep(2000);//this pauses the code for 2 seconds
                                    }
                                    if (subTotal > totalCredits)
                                    {
                                        Console.WriteLine("Insufficent Funds");
                                    }
                                } while (isNumber == false && subTotal>totalCredits);//this will check if the users input wasnt valid if its false then it repeats the loop and checks if the total credits is more than the subTotal
                                totalCredits = totalCredits - subTotal;
                                Console.WriteLine("payment successful");
                                Console.WriteLine("left over balance: {0}",totalCredits);
                                Console.WriteLine("thank you for your purchase");
                                Thread.Sleep(5000);//this will pause the code for 5 seconds
                                subTotal = 0.00M;
                            }
                            else if( insufficientFunds == "n")// if the user input for insufficient funds is n then it executes the code below
                            {
                                Console.WriteLine("Transaction Terminated");
                                Console.WriteLine("You will be refunded your credits");
                                Console.WriteLine("-----------------------------------------------------");
                                subTotal = 0.00M;//resets the subTotal to its origional value
                                totalCredits = 0.00M;//resets the totalCredits to its origional value
                                Thread.Sleep(5000);//pauses the program from executing code for 5 seconds
                            }
                            

                        }
                        else if (subTotal <= totalCredits)
                        {
                            totalCredits = totalCredits - subTotal;
                            Console.WriteLine("Payment successful");
                            Console.WriteLine("remaining balance: {0}", totalCredits);
                            Console.WriteLine("thank you for your purchase");
                            subTotal = 0.00M;
                            Thread.Sleep(5000);//pauses the program from executing the code for 5
                        }
                    }//exit main loop-------------------------------------------------------------------------------------------------------------------------------
                     else if (menuSelection == 3)//Checks if the value of menuSelection is equal to 3
                    {
                        menuSelectionValid = true;
                        exitProgram = true;//this exit the programs main loop
                    }
                    else// if the value the user inputted for menuSelection isn't valid
                    {
                        Console.WriteLine("Please enter a valid integer, these are 1, 2 and 3");
                        Console.WriteLine("");
                    }
                        
                       
                }
               
                

            }
            System.Environment.Exit(1);//exits the code

            
        }
    }
}
