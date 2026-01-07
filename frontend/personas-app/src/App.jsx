import React, { useState, useEffect } from 'react';
import FormularioBase from './components/FormularioBase';
import ListadoPersonas from './components/ListadoPersonas';
import BuscadorPersonas from './components/BuscadorPersonas';
import { personaService } from './services/personaService';

function App() {
  const [vistaActual, setVistaActual] = useState('formularioA');
  const [personasFormularioA, setPersonasFormularioA] = useState([]);
  const [personasFormularioB, setPersonasFormularioB] = useState([]);
  const [personasFiltradas, setPersonasFiltradas] = useState([]);
  const [terminoBusqueda, setTerminoBusqueda] = useState('');

  // Campos para Formulario A (Datos básicos)
  const camposFormularioA = [
    { name: 'nombre', label: 'Nombre', required: true, placeholder: 'Ingrese el nombre' },
    { name: 'apellido', label: 'Apellido', required: true, placeholder: 'Ingrese el apellido' },
    { name: 'correo', label: 'Correo', type: 'email', required: true, placeholder: 'ejemplo@correo.com' },
    { name: 'documento', label: 'Documento', required: true, placeholder: 'Número de documento' }
  ];

  // Campos para Formulario B (Datos extendidos)
  const camposFormularioB = [
    { name: 'nombre', label: 'Nombre Completo', required: true, placeholder: 'Nombre completo' },
    { name: 'apellido', label: 'Apellido Completo', required: true, placeholder: 'Apellidos' },
    { name: 'correo', label: 'Email', type: 'email', required: true, placeholder: 'correo@ejemplo.com' },
    { name: 'documento', label: 'Cédula', required: true, placeholder: 'CC o NIT' },
    { name: 'telefono', label: 'Teléfono', placeholder: 'Número de contacto' }
  ];

  // Cargar todas las personas al inicio
  useEffect(() => {
    cargarPersonas();
  }, []);

  const cargarPersonas = async () => {
    try {
      const personas = await personaService.getAll();
      // Separar personas según su origen (simulado - en un caso real tendrías un campo)
      setPersonasFormularioA(personas.slice(0, Math.ceil(personas.length / 2)));
      setPersonasFormularioB(personas.slice(Math.ceil(personas.length / 2)));
      setPersonasFiltradas(personas);
    } catch (error) {
      console.error('Error al cargar personas:', error);
    }
  };

  const handleSubmitA = async (formData) => {
    try {
      const nuevaPersona = await personaService.create(formData);
      setPersonasFormularioA(prev => [...prev, nuevaPersona]);
      alert('✅ Persona creada en Formulario A');
      cargarPersonas();
    } catch (error) {
      alert('❌ Error: ' + (error.response?.data?.mensaje || error.message));
    }
  };

  const handleSubmitB = async (formData) => {
    try {
      const nuevaPersona = await personaService.create(formData);
      setPersonasFormularioB(prev => [...prev, nuevaPersona]);
      alert('✅ Persona creada en Formulario B');
      cargarPersonas();
    } catch (error) {
      alert('❌ Error: ' + (error.response?.data?.mensaje || error.message));
    }
  };

  const handleDelete = async (id, formulario) => {
    if (window.confirm('¿Está seguro de eliminar esta persona?')) {
      try {
        await personaService.delete(id);
        if (formulario === 'A') {
          setPersonasFormularioA(prev => prev.filter(p => p.id !== id));
        } else {
          setPersonasFormularioB(prev => prev.filter(p => p.id !== id));
        }
        alert('✅ Persona eliminada');
        cargarPersonas();
      } catch (error) {
        alert('❌ Error al eliminar');
      }
    }
  };

  const handleBuscar = async (termino) => {
    setTerminoBusqueda(termino);
    if (!termino) {
      await cargarPersonas();
      return;
    }
    
    try {
      const resultados = await personaService.searchByName(termino);
      setPersonasFiltradas(resultados);
    } catch (error) {
      console.error('Error en búsqueda:', error);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100">
      {/* Header */}
      <header className="bg-blue-600 text-white shadow-lg">
        <div className="container mx-auto px-4 py-6">
          <h1 className="text-3xl font-bold">Sistema de Gestión de Personas</h1>
          <p className="text-blue-100 mt-2">CRUD Full-Stack - React + ASP.NET Core</p>
        </div>
      </header>

      {/* Navegación */}
      <nav className="bg-white shadow-md">
        <div className="container mx-auto px-4">
          <div className="md:flex md:space-x-4 md:py-4 flex flex-wrap space-y-1 py-4 justify-center space-x-1">
            <button
              onClick={() => setVistaActual('formularioA')}
              className={`px-6 py-2 rounded-lg font-medium transition duration-200 ${
                vistaActual === 'formularioA'
                  ? 'bg-blue-600 text-white'
                  : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
              }`}
            >
              📝 Formulario A
            </button>
            <button
              onClick={() => setVistaActual('formularioB')}
              className={`px-6 py-2 rounded-lg font-medium transition duration-200 ${
                vistaActual === 'formularioB'
                  ? 'bg-blue-600 text-white'
                  : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
              }`}
            >
              📋 Formulario B
            </button>
            <button
              onClick={() => setVistaActual('consolidado')}
              className={`px-6 py-2 rounded-lg font-medium transition duration-200 ${
                vistaActual === 'consolidado'
                  ? 'bg-blue-600 text-white'
                  : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
              }`}
            >
              📊 Consolidado
            </button>
          </div>
        </div>
      </nav>

      {/* Contenido Principal */}
      <main className="container mx-auto px-4 py-8">
        {vistaActual === 'formularioA' && (
          <div className="space-y-6">
            <FormularioBase
              campos={camposFormularioA}
              onSubmit={handleSubmitA}
              titulo="Formulario A - Datos Básicos"
            />
            <ListadoPersonas
              personas={personasFormularioA}
              onDelete={(id) => handleDelete(id, 'A')}
              titulo="Personas del Formulario A"
            />
          </div>
        )}

        {vistaActual === 'formularioB' && (
          <div className="space-y-6">
            <FormularioBase
              campos={camposFormularioB}
              onSubmit={handleSubmitB}
              titulo="Formulario B - Datos Extendidos"
            />
            <ListadoPersonas
              personas={personasFormularioB}
              onDelete={(id) => handleDelete(id, 'B')}
              titulo="Personas del Formulario B"
            />
          </div>
        )}

        {vistaActual === 'consolidado' && (
          <div className="space-y-6">
            <BuscadorPersonas onSearch={handleBuscar} />
            <ListadoPersonas
              personas={personasFiltradas}
              onDelete={(id) => handleDelete(id, 'A')}
              titulo={terminoBusqueda ? `Resultados para: "${terminoBusqueda}"` : 'Todas las Personas'}
            />
            <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mt-6">
              <div className="bg-blue-100 p-6 rounded-lg text-center">
                <p className="text-4xl font-bold text-blue-600">{personasFormularioA.length}</p>
                <p className="text-gray-700 mt-2">Formulario A</p>
              </div>
              <div className="bg-green-100 p-6 rounded-lg text-center">
                <p className="text-4xl font-bold text-green-600">{personasFormularioB.length}</p>
                <p className="text-gray-700 mt-2">Formulario B</p>
              </div>
              <div className="bg-purple-100 p-6 rounded-lg text-center">
                <p className="text-4xl font-bold text-purple-600">
                  {personasFormularioA.length + personasFormularioB.length}
                </p>
                <p className="text-gray-700 mt-2">Total</p>
              </div>
            </div>
          </div>
        )}
      </main>

      {/* Footer */}
      <footer className="bg-gray-800 text-white mt-12">
        <div className="container mx-auto px-4 py-6 text-center">
          <p>© 2025 - Prueba Técnica Full-Stack</p>
        </div>
      </footer>
    </div>
  );
}

export default App;