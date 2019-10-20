#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char *argv[])
{
	MYSQL *conn;
	int err;
	int errRegister;
	int err1;
	int err2;
	int err3;
	int err4;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char id[10];
	char consulta [500];
	char consultaRegister[500];
	char consulta1 [500];
	char consulta2 [500];
	char consulta3 [500];
	char consulta4 [500];
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Jugadores",0, NULL, 0);
	
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char Peticion[512];
	char Respuesta[512];
	int conectado = 1;
	// INICIALITZACIONS
	// Obrim el socket
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9050);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	
	for(;;)
	{
	
	//HACEMOS LA CONSULTA DER REGISTER//
	printf ("Escuchando\n");
	sock_conn = accept(sock_listen, NULL, NULL);
	printf ("He recibido conexion\n");
	//sock_conn es el socket que usaremos para este cliente
	// Ahora recibimos su nombre, que dejamos en buff
	ret=read(sock_conn,Peticion, sizeof(Peticion));
	printf ("Recibido\n");
	// Tenemos que a?adirle la marca de fin de string 
	// para que no escriba lo que hay despues en el buffer
	Peticion[ret]='\0';
	//Escribimos el nombre en la consola
	printf ("Se ha conectado: %s\n",Peticion);
	
	int Registrado = 0;
	int Logeado = 0;
	char *p = strtok( Peticion, " ");
	int codigo = atoi(p);
	printf ("codigo:%d\n",codigo);
	
	

	while(!Logeado)
	{
	 if (codigo == 1 && !Registrado)
	 {
	p = strtok( NULL, " ");
	char usernameRegister[20];
	strcpy (usernameRegister, p);
	p = strtok( NULL, " ");
	char passwordRegister[20];
	strcpy (passwordRegister, p);
	char NicknameRegister[20];
	strcpy (NicknameRegister, p);
	printf ("Codigo: %d, Nombre: %s, password: %s,Nickname: %s\n", codigo, usernameRegister,passwordRegister,NicknameRegister);
	
	
	
	strcpy (consultaRegister, "INSERT INTO Jugador VALUES ('20','");
	strcat (consultaRegister, NicknameRegister);
	strcat (consultaRegister, "','");
	strcat (consultaRegister, usernameRegister);
	strcat (consultaRegister, "','");
	strcat (consultaRegister, passwordRegister);
	strcat (consultaRegister, "',0,0,0,0,0)");
	
	errRegister = mysql_query(conn, consultaRegister);
	if (errRegister!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	printf ("ha pasado la inserccion: \n");
	sprintf(Respuesta, "1");
	write (sock_conn,Respuesta, strlen(Respuesta));
	Registrado = 1;
	
	 }

	 
	 close(sock_conn);
	 
	 
	 printf ("Escuchando\n");
	 sock_conn = accept(sock_listen, NULL, NULL);
	 printf ("He recibido conexion\n");
	 //sock_conn es el socket que usaremos para este cliente
	 // Ahora recibimos su nombre, que dejamos en buff
	 ret=read(sock_conn,Peticion, sizeof(Peticion));
	 printf ("Recibido\n");
	 // Tenemos que a?adirle la marca de fin de string 
	 // para que no escriba lo que hay despues en el buffer
	 Peticion[ret]='\0';
	 //Escribimos el nombre en la consola
	 printf ("Se ha conectado: %s\n",Peticion);
	 
	 
	 char *p = strtok( Peticion, " ");
	 int codigo = atoi(p); 
	 printf ("antes de codigo 2\n");
	if (codigo == 2 )//login es un 2
	{
		
		printf ("codigo:%d\n",codigo);
	
		printf ("codigo:%d\n",codigo);
		printf ("dentro codigo 2\n");
		p = strtok( NULL, " ");
		char username[20];
		strcpy (username, p);
		p = strtok( NULL, " ");
		char password[20];
		strcpy (password, p);
		printf ("Codigo: %d, Nombre: %s, password: %s\n", codigo, username,password);
	
	strcpy (consulta, "SELECT Jugador.Password FROM Jugador WHERE Jugador.Usuario = '");
	strcat (consulta, username);
	strcat (consulta, "'");
	err = mysql_query (conn,consulta);
	if (err!=0) 
	{
		printf ("Error al leer los datos",mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Recogemos el resultado de la consulta. El resultado de la consulta se devuelve en una variable del tipo puntero a MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria en la que cada fila contiene los datos de una persona.
	// Ahora obtenemos la primera fila que se almacena en una variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	printf ("%s\n",row[0]);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		if (strcmp(password,row[0])==0)
		{	// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
			sprintf(Respuesta, "1");
			write (sock_conn,Respuesta, strlen(Respuesta));
			Logeado = 1;
		}	
		else
		{
			sprintf(Respuesta, "0");
			write (sock_conn,Respuesta, strlen(Respuesta));
			printf ("Error en usuario o contrase?a");
		}
	}
	
	}

	}
	close(sock_conn); 

	
	for(;;)
	{
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		// Ahora recibimos su nombre, que dejamos en buff
		ret=read(sock_conn,Peticion, sizeof(Peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		Peticion[ret]='\0';
		
		//Escribimos el nombre en la consola
		
		printf ("Se ha conectado: %s\n",Peticion);
		
		
		char *p = strtok( Peticion, "/");
		int codigo =  atoi (p);
		p = strtok( NULL, "/");
		char nombre[20];
		strcpy (nombre, p);
		printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		
		if (codigo ==1) //piden la longitd del nombre
			// Realizamos la consulta: Consulta2
		{
			strcpy (consulta1,"SELECT Jugador.Nickname FROM Jugador,Relacion,Partida WHERE ((Partida.TiempoPartida)=40 AND Partida.id = Relacion.idPartida AND Relacion.idJugador = Jugador.id)");
		err1 = mysql_query (conn, consulta1);
		
		if ((err1!=0)) 
		{
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//Recogemos el resultado de la consulta 
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta2\n");
		else
			// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
			printf ("Jugador que ha ganado la partida con duracion 40 minutos: %s\n", row[0] );
		sprintf(Respuesta, row[0]);
		write (sock_conn,Respuesta, strlen(Respuesta));
	}
		else if (codigo == 2)
		{
			strcpy (consulta2,"SELECT Jugador.Nickname FROM Jugador,Relacion,Partida WHERE Jugador.PartidasPerdidas =(SELECT MAX(Jugador.PartidasPerdidas) FROM Jugador)");
			err2=mysql_query (conn, consulta2);
			
			if ((err2!=0)) 
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//recogemos el resultado de la consulta 
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta5\n");
			else
				// El resultado debe ser una matriz con una sola fila  y una columna que contiene el nombre
				printf ("\nEl jugador que mas partidas ha perdido es: %s\n", row[0] );
			sprintf(Respuesta, row[0]);
			write (sock_conn,Respuesta, strlen(Respuesta));
			
		}
		else if (codigo == 3)
		{
			strcpy (consulta3,"SELECT Partida.Ganador FROM Partida WHERE Partida.TiempoPartida = (SELECT MAX(Partida.TiempoPartida) FROM Partida);");
			
			err3=mysql_query (conn, consulta3);
			
			if ((err3!=0)) 
			{
				printf ("Error al consultar datos de la base3 %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//recogemos el resultado de la consulta 
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta3\n");
			else
				// El resultado debe ser una matriz con una sola fila  y una columna que contiene el nombre
				printf ("\nEl Jugador que ha ganado la partida mas larga es: %s\n", row[0] );
			
			sprintf(Respuesta, row[0]);
			write (sock_conn,Respuesta, strlen(Respuesta));
		}
		
		else if (codigo ==4){
			
			
			// Ahora vamos a buscar el nombre de la persona cuyo DNI es uno dado por el usuario
			printf ("Dame el ID de la persona que quieres buscar\n"); 
			/*scanf ("%s", id);*/
			// construimos la consulta SQL
			printf ("Dame el ID : %s\n",nombre); 
			char id[20];
			strcpy(id,nombre);
			printf ("Dame el ID:%s\n",id);
			strcpy (consulta4,"SELECT Nickname FROM Jugador WHERE id = '");
			strcat (consulta4, id);
			strcat (consulta4,"'");
			
			// Realizamos la consulta: Consulta
			err4=mysql_query (conn, consulta4);
			printf ("haceconsulta ID\n"); 
			if ((err4!=0)) 
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			//recogemos el resultado de la consulta1 
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado);
			printf ("persone despues de la id,%s\n",row[0]); 
			
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta1\n");
			else
				// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
				printf ("Nombre de la persona: %s\n", row[0] );
			
			
			sprintf(Respuesta, row[0]);
			write (sock_conn,Respuesta, strlen(Respuesta));
			
			
		}
			
		
		else if (codigo == 5){
			
			// Se acabo el servicio para este cliente
			close(sock_conn); 
		break;
		}
		    
	}
	
}}

