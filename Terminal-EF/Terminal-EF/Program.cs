using Terminal_EF.Entities;

bool Exit = false;
while (Exit == false)
{
    int menu = Terminal.GetInt($"1)Add Bus\n" +
        $"2)Add Trip\n" +
        $"3)show tripes\n" +
        $"4)book a ticket\n" +
        $"5)Buy a ticket\n" +
        $"6)Cancel the ticket\n" +
        $"7)show total\n" +
        $"0)EXIT");

    switch (menu)
    {
        case 1:
            {

                string name = Terminal.GetString("Enter Bus Name");
                int type = Terminal.GetInt("1)Normal--2)VIP");
                Terminal.AddBus(name, type);
                break;
            }
            case 2:
            {
                int type = Terminal.GetInt("1)Normal--2)VIP");
                Terminal.AddTrip(type);
                break;
            }
            case 3: 
            {
                Terminal.ShowTrip();

                break;
            }
            case 4:
            {
                Terminal.BookTheTicket();
                break;
            }
            case 5:
            {
                Terminal.BuyTheTicket();
                break;
            }
            case 6:
            {
                Terminal.CancelTicket();
                break;
            }
        case 7:
            {
                Terminal.ShowTripTotal();
                break;
            }
    }
}