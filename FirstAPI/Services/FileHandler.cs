using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileHandler<T> // Generic class to handle file operations for any Model type
{
    private readonly string _filePath;// File path for JSON file

    // Constructor to initialize file path
    public FileHandler(string filePath)
    {
        _filePath = filePath;
    }

    // Read data from file and deserialize into a list of Model
    public List<T> ReadProductsFromFile()
    {
        try
        {
            if (!File.Exists(_filePath)) return new List<T>();

            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
        catch (Exception ex)
        {
            // Log the error and return an empty list
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new List<T>();
        }
    }

    // Write list of Model to file as JSON
    public string WriteProductsToFile(List<T> model)
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
            return ("Success writting");
        }
        catch (Exception ex)
        {
            // Log the error
            return($"Error writing to file: {ex.Message}");
        }
    }
}
