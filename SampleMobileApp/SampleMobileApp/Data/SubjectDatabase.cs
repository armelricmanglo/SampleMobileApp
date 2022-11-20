using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SampleMobileApp.Models;

namespace SampleMobileApp.Data
{
    public class SubjectDatabase
    {
        readonly SQLiteAsyncConnection database;
        public SubjectDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Subject>().Wait();
        }
        public Task<List<Subject>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Subject>().ToListAsync();
        }
        public Task<Subject> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Subject>()
            .Where(i => i.subjectID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Subject note)
        {
            if (note.subjectID != 0)
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
        public Task<int> DeleteNoteAsync(Subject note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}
