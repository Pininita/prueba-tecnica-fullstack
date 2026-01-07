import React from 'react';

const ListadoPersonas = ({ personas, onDelete, titulo }) => {
  return (
    <div className="bg-white rounded-lg shadow-md p-6">
      <h3 className="text-xl font-bold mb-4 text-gray-800">{titulo}</h3>
      {personas.length === 0 ? (
        <p className="text-gray-500 text-center py-4">No hay personas registradas</p>
      ) : (
        <div className="overflow-x-auto">
          <table className="w-full">
            <thead>
              <tr className="bg-gray-100 border-b">
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Nombre</th>
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Apellido</th>
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Correo</th>
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Documento</th>
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Teléfono</th>
                <th className="text-left py-3 px-4 font-semibold text-gray-700">Acciones</th>
              </tr>
            </thead>
            <tbody>
              {personas.map((persona) => (
                <tr key={persona.id} className="border-b hover:bg-gray-50">
                  <td className="py-3 px-4">{persona.nombre}</td>
                  <td className="py-3 px-4">{persona.apellido}</td>
                  <td className="py-3 px-4">{persona.correo}</td>
                  <td className="py-3 px-4">{persona.documento}</td>
                  <td className="py-3 px-4">{persona.telefono || 'N/A'}</td>
                  <td className="py-3 px-4">
                    <button
                      onClick={() => onDelete(persona.id)}
                      className="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600 transition duration-200"
                    >
                      Eliminar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default ListadoPersonas;