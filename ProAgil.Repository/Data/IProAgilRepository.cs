using System.Threading.Tasks;
using ProAgil.Domain.Entities;

namespace ProAgil.Repository.Data {
    public interface IProAgilRepository {
        /// <summary>
        /// Tipo Generico
        /// Adicionar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Add<T> (T entity) where T : class;
        /// <summary>
        /// Atualizar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Update<T> (T entity) where T : class;
        /// <summary>
        /// Excluir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Delete<T> (T entity) where T : class;

        Task<bool> SaveChangeAssync ();

        /// <summary>
        /// Obtém Eventos por tema
        /// </summary>
        /// <param name="tehme"></param>
        /// <returns></returns>
        Task<Event[]> GetEventsAssyncByTheme (string theme, bool includeSpeaker);
        
        /// <summary>
        /// Obtém Todos os eventos
        /// </summary>
        /// <param name="includeSpeaker"></param>
        /// <returns></returns>
        Task<Event[]> GetEventsAssync (bool includeSpeaker);

        /// <summary>
        /// Obtém eventos por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="includeSpeaker"></param>
        /// <returns></returns>
        Task<Event> GetEventAssyncById (int Id, bool includeSpeaker);

        /// <summary>
        /// Obtém palestrantes
        /// </summary>
        /// <param name="includeSpeaker"></param>
        /// <returns></returns>
        Task<Speaker[]> GetSpeakersAssync (bool includeSpeaker);

        /// <summary>
        /// Obtém palestrantes por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="includeSpeaker"></param>
        /// <returns></returns>
        Task<Speaker> GetSpeakersAssyncById (int Id, bool includeSpeaker);
    }
}