﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
    /// <summary>
    /// Interfaz usada para Mostrar datos
    /// </summary>
    /// <param name="elemento"></param>
    /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
