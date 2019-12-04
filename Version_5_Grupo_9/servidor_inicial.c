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
#include <pthread.h>
typedef struct{
	char Jugador[20];//username	
	int socket;
	char pass[50];
	int Disponible;
}TJugador;
typedef struct{// partidas de 4 Jugadores
	int Id;
	TJugador Jugadores[4];
	int NumJug;
	int libre;
	int Contestar;
}Partida;



typedef struct{
	
	TJugador conectados[100];
	int num;
	
}TListaConnectados;

typedef struct{
	Partida lista[100];
}TTablaPartidas;

TListaConnectados listaconectados;
TTablaPartidas TablaPartidas;

int BinEscuchado = 9050;
//int BinEscuchado = 50075;/
	/*conn_ID="shiva2.upc.es"    o     "localhost" */ 
	
pthread_mutex_t excluir = PTHREAD_MUTEX_INITIALIZER;
MYSQL *conn;

int sock_conn, sock_listen,ret;//hemos quitado ret

struct sockaddr_in serv_adr;
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
char Peticion[512];
char Respuesta[512];
int conectado = 1;
int i=0;
int sockets[100];

void InicializarTabla(TTablaPartidas *tabla)
{
	for (i = 0; i <100; i++)
	{
		tabla->lista[i].libre = 0;
	}
}

int DameSocket(char nombre[50], TListaConnectados *lista){// retorna el socket del jugador de la lista de jugadores con el nombre entrado
	
	int encontrado = 0;
	int i = 0;
	printf("Jugador que queremos socket:%s \n",nombre);
	while ((i<lista->num) && (!encontrado))
	{
		printf("i:%d, nombre de los conectados:%s, valor del socket conectado:%d \n",i,lista->conectados[i].Jugador,lista->conectados[i].socket);
		if(strcmp(lista->conectados[i].Jugador,nombre)==0)
			encontrado = 1;
		else
			i++;
	}
	
	if (encontrado)
	{
		printf("He encontrado este socket: %d \n",lista->conectados[i].socket);
		return lista->conectados[i].socket;
	}
	else 
		return -1;
}
void DameSocketsPartida (TTablaPartidas *tabla_partidas, int idPartida, TListaConnectados *lista, int sockets_e[4])
{
	//printf("idPartida:%d,sockets:%d \n",idPartida,sockets_e[1]);
	int encontrado = 0;
	int i =0;
	while ( (i<100) && (!encontrado))
	{
		printf("idPartida:%d \n",tabla_partidas->lista[i].Id);
		printf("Dentro bucle encontrado \n");
		if (tabla_partidas->lista[i].Id == idPartida)
		{
			printf("Dentro bucle encontrado \n");
			encontrado = 1;
		}
		else{
			i = i +1;
			
		}
	}
	printf("encontrado:%d\n",encontrado);
	
	char nombrespartida[500];
	int j = 0;
	strcpy(nombrespartida, tabla_partidas->lista[i].Jugadores[j].Jugador);
	for (j = 1; j < tabla_partidas->lista[i].NumJug; j++)
	{
		strcat(nombrespartida, "/");
		strcat(nombrespartida, tabla_partidas->lista[i].Jugadores[j].Jugador);
	}
	printf("nombrespartida:%s \n",nombrespartida);
	char *p;
	p = strtok(nombrespartida, "/");
	char nombre[50];
	i = 0;
	while (nombre != NULL && i < 2)
	{
		strcpy(nombre,p);
		sockets_e[i] = DameSocket(nombre, lista);
		printf("socket dentro de la funcion:%d \n",sockets_e[i]);
		i = i+1;
		p = strtok(NULL, "/");
	}
	
}
int Pon (char nombre[20], int socket, char pasw[50], TListaConnectados *lista)
{// ponemos un jugador en la partida que nos indique
	//Posem els connectats dins de la llista/
		printf("Guardo socket:%d\n", socket);
	if (lista->num < 100)
	{
		lista->conectados[lista->num].socket = socket;
		strcpy(lista->conectados[lista->num].Jugador,nombre);
		strcpy(lista->conectados[lista->num].pass,pasw);
		lista->num=lista->num+1;
		//Notificar a todos los clientes
		return 0;
	}
	else
		return -1;
}


int AnadeJug(Partida *partida, char nombre[20],int socket){//Dada una partida, retorna 0 si la sala esta llena o no
	int i = partida->NumJug;
	
	printf("Funcion a?adir jugador");
	if (i==0){//Nadie en la Partida
		strcpy(partida->Jugadores[0].Jugador,nombre);
		partida->Jugadores[0].socket = socket;
		partida->NumJug++;
		printf("He a?adido a : %s\n",partida->Jugadores[0].Jugador);
		printf("Ahora hay %d jugadores en la partida\n", partida->NumJug);
		return 1;
	}
	else if(i==1)
	{
		strcpy(partida->Jugadores[1].Jugador,nombre);
		partida->Jugadores[1].socket = socket;
		partida->NumJug++;
		printf("He a?adido a : %s\n",partida->Jugadores[1].Jugador);
		printf("Ahora hay %d jugadores en la partida\n", partida->NumJug);
		return 1;	
	}
	else if(i==2)
	{
		strcpy(partida->Jugadores[2].Jugador,nombre);
		partida->Jugadores[2].socket = socket;
		partida->NumJug++;
		return 1;	
	}
	else if(i==3)
	{
		strcpy(partida->Jugadores[3].Jugador,nombre);
		partida->Jugadores[3].socket = socket;
		partida->NumJug = 4;
		return 1;	
	}
	
	else//Partida llena
			return 0;
}

int PonPartida (Partida game, TTablaPartidas *Tabla){//Retorna posicion si lo mete, -1 si maximo partidas
	int encontrado=0;
	int i=0;
	while( (i<100) && (!encontrado)) //Faltaban parentesis
	{
		if (Tabla->lista[i].libre==0)//sabemos que esta libre
		{
			encontrado=1;
		}
		i = i + 1;
	}
	if (encontrado)
	{
		Tabla->lista[i]=game;
		Tabla->lista[i].Id = i;
		Tabla->lista[i].libre=-1;//ponemos que no esta libre
		return i;//devuelve la posicion de la partida
	}
	else
		return -1;	
}

int BuscarUserName (char nom[50], TListaConnectados *lista){
	
	int encontrado = 0;	
	int cont = 0;
	
	while ((cont<lista->num) && !encontrado)
	{
		if(strcmp(lista->conectados[cont].Jugador,nom)==0)
		{
			encontrado = 1;
		}
		else 
		   cont+=1;
	}
	if (encontrado==1)
	{
		return 1;
	}
	else 
	{
		return 0;
	}
}

int EliminarJugador(char nom[50], TListaConnectados *lista){// eliminamos jugador de la lista de jugadores i por lo tanto del servidor	
	//return -1 si no elimina return 1 elimina el jugador
	int encontrado = 0;
	int cont = 0;
	while ((cont<lista->num) && !encontrado)
	{
		if(strcmp(lista->conectados[cont].Jugador,nom)==0)
		{
			encontrado = 1;
		}
		else 
		   cont+=1;
	}
	if (encontrado)
	{
		lista->num-=1;
		while (cont<lista->num)
		{
			lista->conectados[cont]=lista->conectados[cont+1];
			cont+=1;
		}
		printf("estamos aqui\n");
		return 1;
	}	
	else 
		return -1;
}

void DameConectados(TListaConnectados *lista, char conectados[1000]){// funcion que retorna todos los nombres de los conectados actuales en el servidor
	sprintf(conectados,"%d",lista->num);
	printf("%d\n",lista->num);
	int i;
	for (i=0; i<lista->num;i++)
		sprintf(conectados,"%s %s",conectados,lista->conectados[i].Jugador);
}

void ConexionInicial()	
{//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	//"shiva2.upc.es"
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "TG9_Jugadores",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}

void InicializacionSocket()	
{// INICIALITZACIONS	
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
	serv_adr.sin_port = htons(BinEscuchado);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
}

void EscuchandoSocket(){	
	//HACEMOS LA CONSULTA DER REGISTER//
	/*	printf ("Escuchando\n");*/
	/*	sock_conn = accept(sock_listen, NULL, NULL);*/
	/*	printf ("He recibido conexion\n");*/
	//sock_conn es el socket que usaremos para este cliente
	// Ahora recibimos su nombre, que dejamos en buff
	ret=read(sock_conn,Peticion, sizeof(Peticion));
	printf ("Recibido\n");
	// Tenemos que a?adirle la marca de fin de string 
	// para que no escriba lo que hay despues en el buffer
	Peticion[ret]='\0';
	//Escribimos el nombre en la consola
	printf ("Se ha conectado: %s\n",Peticion);
}

void ConsultaRegister(int Registrado,char NicknameRegister[100],char usernameregister[100],char passwordRegister[100])	
{	
	strcpy (consultaRegister, "INSERT INTO Jugador VALUES ('20','");//mirar de cambiar el 20 por un contador	
	strcat (consultaRegister, NicknameRegister);
	strcat (consultaRegister, "','");
	strcat (consultaRegister, usernameregister);
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
	sprintf(Respuesta, "-1/");
	write (sock_conn,Respuesta, strlen(Respuesta));
	Registrado = 1;
}

int ConsultaLogin(int Logeado,char username[100],char password[100])
{
	
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
		
		int res = BuscarUserName(username,&listaconectados);
		
		printf ("%d\n",res);
		if (strcmp(password,row[0])==0 && res==0 )//no puede estar en la lista de conectados! y encima el passsword ha de coincidir
			
		{	// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
			
			
			
			sprintf(Respuesta,"0/%s","1");
			
			write(sock_conn,Respuesta, strlen(Respuesta));
			
			
			return 1;
			
		}	
		
		else 
			
		{
			
			sprintf(Respuesta,"0/%s","-1");
			
			write (sock_conn,Respuesta, strlen(Respuesta));
			
			printf ("Error en usuario o contrase?a\n");
			
			return -1;
			
		}
		
	}
	
	
	
}



void Consulta1(int err1)
	
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
		
		printf ("No se han obtenido datos en la consulta1\n");
	
	else
		
		// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
		
		printf ("Jugador que ha ganado la partida con duracion 40 minutos: %s\n", row[0] );
	
	sprintf(Respuesta,"1/%s",row[0]);
	
	write (sock_conn,Respuesta, strlen(Respuesta));
	
}

void Consulta2(int err2)
	
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
	
	sprintf(Respuesta,"2/%s",row[0]);
	
	write (sock_conn,Respuesta, strlen(Respuesta));
	
	
	
}

void Consulta3(int err3)
	
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
	sprintf(Respuesta,"3/%s",row[0]);
	
	
	
	write (sock_conn,Respuesta, strlen(Respuesta));
	
}



void Consulta4(char nombre[20],int err4)
	
{
	
	// Ahora vamos a buscar el nombre de la persona cuyo DNI es uno dado por el usuario
	
	printf ("Dame el ID de la persona que quieres buscar\n"); 
	
	//scanf ("%s", id);/
		
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
	
	printf ("hace consulta ID\n"); 
	
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
	
	sprintf(Respuesta,"4/%s",row[0]);
	printf ("persone con id,%s\n",Respuesta); 
	write (sock_conn,Respuesta, strlen(Respuesta));	
}

void *AtenderCliente(void *socket)	
{
	
	char peticion[512];
	char respuesta[512];
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn = *s;
	char Username[25];
	char password[50];
	char Nickname[30];
	int Logeado = 0;
	int Registrado = 0;
	int ret;
	int terminar = 0;
	
	InicializarTabla(&TablaPartidas);
	
	while(terminar ==0)
	{
		EscuchandoSocket();
		
		char *p = strtok(Peticion,"/");
		int codigo =  atoi (p);
		printf("codigoprimero es:%d \n",codigo);
		if(codigo == 6 || codigo == 7 || codigo == 8)
		{
			printf("dentrodel codigo 6 o 7 o 8 con codigo:%d \n", codigo);
			if (codigo == 6)
			{
				printf("peticion:%s \n", p);
				
				printf("estamos en codigo 6:%d \n", codigo);
				
				p = strtok(NULL,"/");//Sacamos numero de jugadores
				
				printf("max:%s \n", p);
				int max = atoi(p);
				
				p = strtok(NULL,"/");
				strcpy(Username,p);
				Partida PartidaNueva;
				PartidaNueva.NumJug = 0;
				printf("Creador de la partida:%s \n",Username);
				
				AnadeJug(&PartidaNueva,Username,DameSocket(Username,&listaconectados));//A??adimos creador sala
				printf("metemos a %s \n",PartidaNueva.Jugadores[0].Jugador);
				PartidaNueva.Jugadores[0].Disponible = 1;
				printf("estamos3 \n");
				PartidaNueva.Contestar++;
				
				printf("estamos51 \n");
				
				int enviosock[3];
				int i;
				for(i=0;i<max;i++)//Llenamos la partida
				{
					
					char jugador[20];
					p=strtok(NULL,"/");//Sacamos nombre de jugador
					strcpy(jugador,p);
					printf("a??adido:%s \n",jugador);
					int err=AnadeJug(&PartidaNueva,jugador,DameSocket(jugador,&listaconectados));
					printf("A?adimos a %s \n",jugador);
					if (err=0)
					{
						break;
					}
					
					int sockjug=DameSocket(jugador,&listaconectados);//Buscamos socket jugadores
					enviosock[i]=sockjug;
					printf("estamos enviando al jugador invitado :%s con socket:%d\n",jugador, enviosock[i]);
				}
				
				pthread_mutex_lock(&excluir);
				int partida=PonPartida(PartidaNueva,&TablaPartidas);//Ponemos partida y esperamos la aceptacion
				pthread_mutex_unlock(&excluir);
				if (partida == -1){//Todas las partidas llenas
					sprintf(respuesta,"7/1");
					pthread_mutex_lock(&excluir);
					int socket = DameSocket(Username,&listaconectados);
					write(socket,respuesta, strlen(respuesta));
					pthread_mutex_unlock(&excluir);
				}
				else{//Hay espacio para partidas
					printf("UsernameInvitador :%s\n",Username);
					sprintf(respuesta,"7/0/%s/%d",Username,partida);// Mensaje = 10/0/contraquien/en que partida
					printf("respuesta111a: %s \n",respuesta);
					printf("Hay %d \n",TablaPartidas.lista[0].NumJug);
					//printf("NumJugadoresenpartida:%s \n",PartidaNueva.NumJug);
					int s;
					for(s=0; s<2;s++)
					{
						write (enviosock[s],respuesta, strlen(respuesta));
						//write (sockets[s],respuesta, strlen(respuesta));
						printf("Enviado peticion a %d \n",enviosock[s]);
					}
					int k;
					for(k=0;k<2;k++){
						printf("vector de enviosokets:%d \n",enviosock[k]);
						printf("vector de sockets:%d \n",sockets[k]);
					}
				}
			}
			
			printf("codigo7fuera  \n");
			if(codigo == 7)
			{// recibimos respuesta a peticion de jugar
				// 11/1/quien/quepartida --> Quiero Jugar
				// 11/0/quien/quepartida --> No Quiero Jugar
				// Enviar a socket de quien nos hizo peticion si queremos o no jugar mensaje ( 11/SI o NO/ DE PArte de quien)
				printf("codigo7dentro \n");
				p=strtok(NULL,"/");
				int respuesta1= atoi(p);
				p=strtok(NULL,"/");
				char Usuario[20];
				strcpy(Usuario,p);
				p=strtok(NULL,"/");
				int partida=atoi(p);
				pthread_mutex_lock(&excluir);
				int j;
				int encontrado;
				printf("respuesta:%d, Usuario:%s, Partida:%d \n",respuesta1,Usuario,partida);
				while (j<TablaPartidas.lista[partida].NumJug && !encontrado)
				{
					if(strcmp(TablaPartidas.lista[partida].Jugadores[j].Jugador,Usuario)==0)
					{
						if (respuesta1==1)
						{
							TablaPartidas.lista[partida].Jugadores[j].Disponible=1;
							TablaPartidas.lista[partida].Contestar++;
						}
						else
						{
							TablaPartidas.lista[partida].Jugadores[j].Disponible=-1;
							TablaPartidas.lista[partida].Contestar++;
						}
						encontrado=1;
					}
					else
					   j++;
				}
				pthread_mutex_unlock(&excluir);
				
				if (TablaPartidas.lista[partida].Contestar==TablaPartidas.lista[partida].NumJug)
				{//Enviamos mensaje a todos los clientes de como queda la partida
					char texto[512];
					int num = 0;
					int sig = 0;
					pthread_mutex_lock(&excluir);
					printf("veamosque pasa3: %d \n",TablaPartidas.lista[partida].NumJug);
					while(sig<TablaPartidas.lista[partida].NumJug)
					{
						num=num+TablaPartidas.lista[partida].Jugadores[sig].Disponible;
						sig = sig + 1;
					}
					
					if (num==TablaPartidas.lista[partida].NumJug)
					{
						sprintf(texto,"START");
					}
					else
					{
						sprintf(texto,"NOPE");
						TablaPartidas.lista[partida].libre=0;
					}
					
					pthread_mutex_unlock(&excluir);
					sprintf(respuesta,"8/%s",texto);
					printf("respuesta2:%s \n",respuesta);
					
					int send;
					char envio[512];
					for(send=0; send<TablaPartidas.lista[partida].NumJug;send++)
					{
						
						sprintf(envio,"%s/%d/%d",respuesta,send,TablaPartidas.lista[partida].NumJug);
						printf("envio:%s \n",envio);
						printf("%s \n",TablaPartidas.lista[partida].Jugadores[send].Jugador);
						int jug=DameSocket(TablaPartidas.lista[partida].Jugadores[send].Jugador,&listaconectados);
						write (jug,envio, strlen(envio));
						
					}
				}
			}
			printf("antes de codigo 8 \n");
			if (codigo == 8)
			{
				printf("Entro en el codigo 8 peticion:%s \n",Peticion);
				char jugadorenvia[30];
				p =strtok(NULL,"/");
				strcpy(jugadorenvia,p);
				
				printf("Entro en el codigo 8 \n");
				
				char frase[500];
				p =strtok(NULL,"/");
				strcpy(frase,p);
				printf("Entro en el codigo p:%s \n",frase);
				int IDpartida;
				p=strtok(NULL,"/");//Sacamos nombre de jugador
				IDpartida = atoi(p);
				printf("Entro en el codigo 8 IDpartida:%d \n",IDpartida);
				int sockets_enviar[4];
				DameSocketsPartida(&TablaPartidas,IDpartida,&listaconectados,sockets_enviar);
				
				sprintf(respuesta,"9/%s/%s",jugadorenvia,frase);
				int k;
				for(k=0; k<4 && sockets_enviar[k] != 0;k++)
				{
					printf("Entro en el codigo 8 socket_enviar:%d \n",sockets_enviar[k]);
					
				}
				int s;
				printf("Entro en el codigo 8 respuesta:%s \n",respuesta);
				for(s=0; s<4 && sockets_enviar[s]!=0; s++)
				{
					write (sockets_enviar[s],respuesta, strlen(respuesta));
					//write (sockets[s],respuesta, strlen(respuesta));
					printf("Enviado respuesta %s a %d \n",respuesta,sockets_enviar[s]);
				}
				
			}
			
		}
		
		else	
		{
			p = strtok( NULL, "/");
			char Username[20];
			strcpy (Username, p);
			p = strtok( NULL, "/");
			char Password[20];
			strcpy (Password, p);
			p = strtok( NULL, "/");
			
			char Nickname[20];
			
			strcpy (Nickname, p);
			char Notificacion[500];		
			printf ("Codigo: %d, Nombre: %s\n", codigo, Username);			
			printf (" Peticion1: %s\n", Peticion);	
			if (codigo==0)
			{
				int Logeado = 0;
				int log = ConsultaLogin(Logeado,Username,Password);
				printf ("Se ha logeado despues: %d\n",log);
				pthread_mutex_lock(&excluir);
				if (log == 1)
				{
					int res = Pon(Username,sock_conn ,Password,&listaconectados);
				}
				else if (log == -1)
				{
					ConsultaRegister(Registrado,Nickname,Username,Password);
					int log = ConsultaLogin(Logeado,Username,Password);
					if (log ==1)
					{
						int res = Pon(Username,sock_conn ,Password,&listaconectados);
					}
				}
				pthread_mutex_unlock(&excluir);
			}
			
			if (codigo ==1) //piden la longitd del nombre
				
				// Realizamos la consulta: Consulta2
				
			{
				
				Consulta1(err1);
				
			}
			
			else if (codigo == 2)
				
			{
				
				Consulta2(err2);
				
			}
			
			else if (codigo == 3)
				
			{
				
				Consulta3(err3);
				
			}
			
			
			
			else if (codigo ==4)
				
			{
				
				Consulta4(Username,err4);
				
			}
			else if (codigo == 5){
				
				pthread_mutex_lock(&excluir);
				
				char conectados[1000];
				char notificacion[500];
				int res = EliminarJugador(Username,&listaconectados);
				char Respuesta [250];
				DameConectados(&listaconectados,conectados);
				
				sprintf(Respuesta,"5/%s",conectados);
				write(sock_conn,Respuesta, strlen(Respuesta));
				printf("%s\n",conectados);	
				printf("hEMOS DESCONECTADO AL JUGADOR : %s\n",Username);	
				
				pthread_mutex_unlock(&excluir);
				
				terminar=1;			
			}
		}
		
		
		if ((codigo == 0) || (codigo == 1) || (codigo == 2) || (codigo == 3) || (codigo == 4)|| (codigo == 5)) {
			
			char notificacion[500];
			printf("estamos Tabla Conectados\n");
			//creamos respuesta de la notificacion/
				char conectados[1000];
			pthread_mutex_lock(&excluir);
			DameConectados(&listaconectados,conectados);
			pthread_mutex_unlock(&excluir);
			
			sprintf(notificacion,"6/%s",conectados);
			//enviamos notifiacion a todos los sockets/
				printf("despues de conectados\n");
			printf("%s\n",conectados);	
			int j=0;
			
			printf("Hay %d usuarios conectados \n", listaconectados.num);
			for(j=0;j<listaconectados.num; j++)
				
			{
				write(listaconectados.conectados[j].socket,notificacion,strlen(notificacion));
				printf("Dentro For TablaConectados\n");
			}	
		}
		
	}
	close(sock_conn);
	
}
int main(int argc, char *argv[])	
{	
	ConexionInicial();	
	InicializacionSocket();
	pthread_t thread[100];
	
	for(;;)
	{
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[i] = sock_conn;
		pthread_create (&thread[i],NULL,AtenderCliente,&sockets[i]);
		i = i + 1;
	}
}