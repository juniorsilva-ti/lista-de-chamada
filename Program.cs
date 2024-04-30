using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
 
class Program
{
    static List<string> alunosMatriculados = new List<string> {" “13306”, “13329”, “13460”, “14506”, “14395”, “11224”,  “14433”, “14439”, “13779”, “14293”, “14250”, “04387”, “13722”, “12390”, “13512”, “14558”, “14136”, “14406”, “14446”, “14562”, “14271”, “14399”, “14415”, “14146”, “14321”, “14556”, “13728”, “14365”, “13494”, “14011”, “14454”, “14367”, “14473”, “14221”, “14416” “14472”, “13454”, “14528”, “13531”, “12335”, “14391”, “11075”, “14557";
    static List<string> alunosPresentes = new List<string>();
    static List<string> alunosAusentes = new List<string>();
 
    static void Main()
    {
        Console.WriteLine("Bem-vindo à chamada. Insira o número do seu RM ou digite 'fim' para encerrar a chamada.");
 
        string inputRM;
        do
        {
            Console.Write("RM: ");
            inputRM = Console.ReadLine();
 
            if (inputRM.ToLower() != "fim")
            {
                if (alunosMatriculados.Contains(inputRM))
                {
                    Console.WriteLine("Presente!");
                    alunosPresentes.Add(inputRM);
                }
                else
                {
                    Console.WriteLine("Ausente!");
                    alunosAusentes.Add(inputRM);
                }
            }
        } while (inputRM.ToLower() != "fim");
 
        EnviarListaPorEmail();
        
        Console.WriteLine("\nLista Final:");
        Console.WriteLine("Alunos Presentes: " + string.Join(", ", alunosPresentes));
        Console.WriteLine("Alunos Ausentes: " + string.Join(", ", alunosAusentes));
    }
 
    static void EnviarListaPorEmail()
    {
        // Configurar as credenciais do remetente
        string remetenteEmail = "seuemail@exemplo.com";
        string remetenteSenha = "suasenha";
 
        // Configurar o cliente SMTP para enviar o e-mail
SmtpClient clienteSmtp = new SmtpClient("smtp.exemplo.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(remetenteEmail, remetenteSenha),
            EnableSsl = true,
        };
 
        // Construir a mensagem de e-mail
        MailMessage mensagem = new MailMessage(remetenteEmail, "destinatario@exemplo.com")
        {
            Subject = "Lista de Chamada",
            Body = $"Alunos Presentes: {string.Join(", ", alunosPresentes)}\nAlunos Ausentes: {string.Join(", ", alunosAusentes)}"
        };
 
        // Enviar o e-mail
        clienteSmtp.Send(mensagem);
    }
}