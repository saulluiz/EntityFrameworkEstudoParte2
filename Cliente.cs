namespace EntityFrameWorkEstudo1{
    public class Cliente{ //Modelo de entidade
        public int Id {get;set;}
        //Automaticamente Id sera uma primary key, devido a convencao pelo nome
        public string Nome {get;set;}
    }
}