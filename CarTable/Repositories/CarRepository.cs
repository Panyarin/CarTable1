using System;
using CarTable.MVVM.Models;
using SQLite;

namespace CarTable.Repositories;

public class CarRepository
{
    SQLiteConnection connection;
    public string StatusMessage;
    public CarRepository()
    {
        connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        connection.CreateTable<Car>();
    }

    public void AddOrUpdate(Car car)
    {
        int result = 0;
        try
        {
            if (car.CarID != 0)
            {
                result = connection.Update(car);
                StatusMessage = $"{result} row(s) updated";
            }
            else
            {
                result = connection.Insert(car);
                StatusMessage = $"{result} row(s) added";
            }

        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Car> GetAll()
    {
        try
        {
            return connection.Table<Car>().ToList();
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public Car Get(int id)
    {
        try
        {
            return connection.Table<Car>().FirstOrDefault(x => x.CarID == id);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public void Delete (int id)
    {
        try
        {
           var car = Get(id);
           connection.Delete(car);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }






}