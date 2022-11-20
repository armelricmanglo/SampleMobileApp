using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SampleMobileApp.Models;

namespace SampleMobileApp.Data
{
    public class TDLDatabase
    {
        readonly SQLiteAsyncConnection database;
        public TDLDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TDL>().Wait();
        }
        public Task<List<TDL>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<TDL>().ToListAsync();
        }
        public Task<TDL> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<TDL>()
            .Where(i => i.tdlID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(TDL note)
        {
            if (note.tdlID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(TDL note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }


    }
}
