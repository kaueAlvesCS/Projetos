using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escreva quantos produtos sua loja vai ter: ");
        int answer = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Qual dificuldade você quer jogar?\n\nEasy\nMedium\nHard\n");
        string dificuldade = Console.ReadLine().ToLower();
        
        while (dificuldade != "easy" && dificuldade != "medium" && dificuldade != "hard"){
            Console.WriteLine("Texto inválido.\nDigite novamente a dificuldade: ");
            dificuldade = Console.ReadLine().ToLower();
        }
        
        int vida = 0;
        if(dificuldade == "easy"){
            vida = 5;
        }else if(dificuldade == "medium"){
            vida = 3;
        }else{
            vida = 1;
        }
        
        string[,] listaGeral = new string[2, answer];
        
        for(int i = 0; i < answer; i++){
            Console.WriteLine($"Digite o nome do {i+1}° produto: ");
            listaGeral[0, i] = Console.ReadLine(); 
            
            Console.WriteLine($"Digite o preço de {listaGeral[0, i]}: ");
            listaGeral[1, i] = Console.ReadLine(); 
        }
        
        Console.WriteLine("-------------------------\nLista dos produtos inseridos");
        for(int i = 0; i < answer; i++){
            Console.WriteLine($"{listaGeral[0, i]} -> R$: {listaGeral[1, i]}");
        }
        
        Console.WriteLine("Deseja mudar algum produto?\nSe sim, digite o nome do produto (ou aperte Enter para pular):");
        string alteracao = Console.ReadLine().ToLower();
        
        for(int i = 0; i < answer; i++){
            if(listaGeral[0, i].ToLower() == alteracao){
                Console.WriteLine("Produto encontrado!");
                Console.WriteLine($"Nome: {listaGeral[0, i]}");
                Console.WriteLine($"Preço: {listaGeral[1, i]}");
                Console.WriteLine("Escreva 'Nome' para alterar ou 'Preço'");
                string alteracao2 = Console.ReadLine().ToLower();
                
                if(alteracao2 == "nome"){
                    Console.WriteLine("Digite o novo nome: ");
                    listaGeral[0, i] = Console.ReadLine(); 
                }else if(alteracao2 == "preço" || alteracao2 == "preco"){
                    Console.WriteLine("Digite o novo preço: ");
                    listaGeral[1, i] = Console.ReadLine(); 
                }
            }
        }
        
        Console.WriteLine("-------------------------\nLista de produtos pronta! Começando o jogo...");
        
        Random rand = new Random();
        
        while(vida != 0){
            int produtoNome = rand.Next(0, answer);
            double quantidade = rand.Next(1, 10);
            Console.WriteLine("\nUm cliente quer comprar um produto!!!");
            Console.WriteLine("------------------------------");
            
            Console.WriteLine($"Produto: {listaGeral[0, produtoNome]}");
            Console.WriteLine($"Quantidade: {quantidade}");
            Console.WriteLine("\nDigite a quantidade que ele deve pagar: ");
            double total = double.Parse(Console.ReadLine());
            
            double precoCorreto = double.Parse(listaGeral[1, produtoNome]);
            
            if(total != (quantidade * precoCorreto)){
                Console.WriteLine("Você errou!");
                vida--;
                Console.WriteLine($"Vidas restantes: {vida}");
            }else{
                Console.WriteLine("Você acertou!");
            }
        }
        
        if(vida == 0){
            Console.WriteLine("Você foi demitido!");
        }
    }
}
