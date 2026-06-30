// CSV Reader Service

// This one has -one- responsibility, and it's to read the CSV file and return a list of Digimon objects.
using System.Linq;
using Kodehode_Assignment_4.Models;

namespace Kodehode_Assignment_4.Services;

public class CsvReader
{
    public List<Digimon> ReadDigimon(string path)
    {
        var digimons = new List<Digimon>();

        if (!File.Exists(path))
            throw new FileNotFoundException($"Could not find file: {path}");

        var lines = File.ReadAllLines(path);

        foreach (var line in lines.Skip(1))
        {
            var columns = line.Split(',');

            if (columns.Length < 7)
                continue;

            if (!int.TryParse(columns[0], out int number))
                continue;

            if (!int.TryParse(columns[5], out int memory))
                continue;

            if (!int.TryParse(columns[6], out int equipSlots))
                continue;

            var digimon = new Digimon
            {
                Number = number,
                Name = columns[1],
                Stage = ParseStage(columns[2]),
                Type = columns[3],
                Attribute = columns[4],
                Memory = memory,
                EquipSlots = equipSlots
            };

            digimons.Add(digimon);
        }

        return digimons;
    }

    private Stage ParseStage(string value)
    {
        return value switch
        {
            "Baby" => Stage.Baby,
            "In-Training" => Stage.InTraining,
            "Rookie" => Stage.Rookie,
            "Champion" => Stage.Champion,
            "Ultimate" => Stage.Ultimate,
            "Mega" => Stage.Mega,
            "Ultra" => Stage.Ultra,
            "Armor" => Stage.Armor,
            _ => Stage.Unknown
        };
    }
}