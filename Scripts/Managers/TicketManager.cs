using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Windows.Forms;


public class Ticket
{
    public int number;
    public DateTime timestamp;
    public string type;
}

public class TicketManager
{
    private string filePath = "tickets.json";
    private AudioManager audioPlayer = new AudioManager();
    public string ServerIP = "171.22.30.82";

    private string[] ticketTypes = {
        "защита диплома",
        "сдача задолженности",
        "сдача зачёта",
        "сдача отчёта",
        "сдача экзамена"
    };

    //--------------------------------------------------------------------------------------------

    public string[] GetTypes()
    {
        return ticketTypes;
    }

    #region Saving/Loading
    public List<Ticket> LoadTickets()
    {
        if (!File.Exists(filePath))
            return new List<Ticket>();

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Ticket>>(json);
    }

    public void SaveTickets(List<Ticket> tickets)
    {
        string json = JsonConvert.SerializeObject(tickets, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    #endregion

    #region Managing
    public Ticket CreateTicket(string type)
    {
        List<Ticket> tickets = LoadTickets();
        Ticket ticket = new Ticket();

        if (tickets.Count > 0)
        {
            Ticket last = tickets[tickets.Count - 1];
            ticket.number = last.number + 1;
        }
        else
        {
            ticket.number = 0;
        }
        ticket.timestamp = DateTime.Now;
        ticket.type = type;
        tickets.Add(ticket);

        SaveTickets(tickets);
        return ticket;
    }

    public Ticket CallNextTicket()
    {
        List<Ticket> tickets = LoadTickets();
        if (tickets.Count <= 0) return null;
        Ticket next = tickets[0];

        if (next != null)
        {
            try
            {
                WebClient client = new WebClient();
                client.UploadStringAsync(new Uri("http://" + ServerIP + "/api/add-token"), "POST");
            }
            catch (Exception e) { }

            audioPlayer.PlayTicket(next);
            tickets.RemoveAt(0);
            SaveTickets(tickets);
        }


        return next;
    }
    #endregion
}