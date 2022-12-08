/*
 * UART.c
 *
 * Created: 09/11/2021 20:06:36
 * Author : ashraf
 */ 
#define  F_CPU 8000000UL
#include <util/delay.h>
#include <avr/io.h>
#include "USART.h"
#include "Macros.h"

int main(void)
{   
	int n;
	char* z;
	char y;
	UART_vInit(9600);
	char x[7];
	DDRA=0x00;
	y=0;
    while (1) 
    {
	  if(y!=PINA){
		 y=PINA;
		 for(n=0;n<8;n++){
			x[n]=Read_bit(PINA,n);
			x[n]+=0x30;
		 }
		 z = &x;
		 UART_vSendstring(z);
		 
    }
}
}
