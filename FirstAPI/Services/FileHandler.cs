using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

/// <summary>
/// Generic class to handle file operations for any model type.
/// This class provides functionality to read and write data in JSON format.
/// </summary>
/// <typeparam name="T">The type of objects to be stored in the file.</typeparam>
public class FileHandler<T>
{
    private readonly string _filePath; // Path of the JSON file where data is stored.

    /// <summary>
    /// Initializes a new instance of the <see cref="FileHandler{T}"/> class.
    /// </summary>
    /// <param name="filePath">The file path where JSON data will be read from or written to.</param>
    public FileHandler(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Reads data from the JSON file and deserializes it into a list of objects.
    /// </summary>
    /// <returns>A list of deserialized objects of type <typeparamref name="T"/>. 
    /// Returns an empty list if the file does not exist or if an error occurs.</returns>
    public List<T> ReadProductsFromFile()
    {
        try
        {
            // Check if the file exists; return an empty list if it doesn't.
            if (!File.Exists(_filePath)) return new List<T>();

            // Read the JSON content from the file.
            var jsonData = File.ReadAllText(_filePath);

            // Deserialize the JSON data into a list of objects of type T.
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
        catch (Exception ex)
        {
            // Log the error and return an empty list if an exception occurs.
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new List<T>();
        }
    }

    /// <summary>
    /// Serializes a list of objects and writes it to the JSON file.
    /// </summary>
    /// <param name="model">The list of objects to be written to the file.</param>
    /// <returns>A success message if the operation is successful, otherwise an error message.</returns>
    public string WriteProductsToFile(List<T> model)
    {
        try
        {
            // Serialize the list of objects into a formatted JSON string.
            var jsonData = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to the file.
            File.WriteAllText(_filePath, jsonData);

            return "Successfully written to file.";
        }
        catch (Exception ex)
        {
            // Log and return the error message in case of an exception.
            return $"Error writing to file: {ex.Message}";
        }
    }
}
