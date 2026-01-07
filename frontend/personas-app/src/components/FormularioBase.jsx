import React, { useState } from 'react';

const FormularioBase = ({ campos, onSubmit, titulo }) => {
  const [formData, setFormData] = useState(() => {
    const initialData = {};
    campos.forEach(campo => {
      initialData[campo.name] = '';
    });
    return initialData;
  });

  const [errores, setErrores] = useState({});

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    if (errores[name]) {
      setErrores(prev => ({ ...prev, [name]: '' }));
    }
  };

  const validarFormulario = () => {
    const nuevosErrores = {};
    
    campos.forEach(campo => {
      if (campo.required && !formData[campo.name]) {
        nuevosErrores[campo.name] = `${campo.label} es obligatorio`;
      }
      
      if (campo.type === 'email' && formData[campo.name]) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(formData[campo.name])) {
          nuevosErrores[campo.name] = 'Email inválido';
        }
      }
    });

    setErrores(nuevosErrores);
    return Object.keys(nuevosErrores).length === 0;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    
    if (validarFormulario()) {
      onSubmit(formData);
      const resetData = {};
      campos.forEach(campo => {
        resetData[campo.name] = '';
      });
      setFormData(resetData);
    }
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-6">
      <h2 className="text-2xl font-bold mb-6 text-gray-800">{titulo}</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        {campos.map(campo => (
          <div key={campo.name}>
            <label htmlFor={campo.name} className="block text-sm font-medium text-gray-700 mb-1">
              {campo.label} {campo.required && <span className="text-red-500">*</span>}
            </label>
            <input
              type={campo.type || 'text'}
              id={campo.name}
              name={campo.name}
              value={formData[campo.name]}
              onChange={handleChange}
              placeholder={campo.placeholder}
              className={`w-full px-4 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent ${
                errores[campo.name] ? 'border-red-500' : 'border-gray-300'
              }`}
            />
            {errores[campo.name] && (
              <span className="text-red-500 text-sm mt-1">{errores[campo.name]}</span>
            )}
          </div>
        ))}
        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 px-4 rounded-lg hover:bg-blue-700 transition duration-200 font-medium"
        >
          Guardar
        </button>
      </form>
    </div>
  );
};

export default FormularioBase;