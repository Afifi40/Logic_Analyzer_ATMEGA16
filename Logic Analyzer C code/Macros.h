/*
 * Macros.h
 *
 * Created: 22/08/2021 17:01:22
 *  Author: ashraf
 */ 

#define Register_Size               8
#define Set_bit(reg,n)           reg |=(1<<n)
#define Clear_bit(reg,n)         reg &=~(1<<n)
#define Toggle_bit(reg,n)        reg ^=(1<<n)
#define Read_bit(reg,n)          ((reg &(1<<n))>>n)
#define IS_bit_Set(reg,n)        ((reg &(1<<n))>>n)
#define IS_bit_Clear(reg,n)      !((reg &(1<<n))>>n)
#define ROR(reg,n)               reg=(reg>>n)|(reg<<(Register_Size-n))
#define ROl(reg,n)               reg=(reg<<n)|(reg<<(Register_Size-n))