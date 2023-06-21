# STM32F401_DDS_Signal_Generator

This is an update on my earlier Instructable: 10 Resistor Arduino Waveform Generator with an aim to maximize the Direct-Digital-Synthesis (DDS) signal generator frequency obtainable with the STM32F401CCU6 using the inbuilt Direct-Memory-Access (DMA) mode.

While the Arduino UNO operates at a clock frequency of 16MHz and the DDS clock obtained was ~372kHz, the STM32F401 has a clock frequency of 84MHz and the DDS clock obtained is 8.4Mhz. With this ~22 times improvement in DDS clock the signal generator maximum frequency is significantly increased.

The maximum sinewave frequency obtained with the STM32 is 1MHz.

The STM32F401CCU6 Black-Pill has the advantage of USB connectivity and inbuilt features such as multiple timers, digital I/O and multiple DMA channels. The detailed methodology of using these features is explained in the following steps.

A Windows Graphical-User-Interface (GUI) has also been developed in VS2019 to provide commands to the unit via a PC USB port.
