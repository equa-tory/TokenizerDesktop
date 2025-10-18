using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class TicketStorage
{
    private string filePath = "tickets.json";

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
}
