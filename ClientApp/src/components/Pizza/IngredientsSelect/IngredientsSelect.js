import React, { useEffect, useState } from 'react';
import { getPizzaIngredients } from '../../api-products/ProductsService';

const IngredientsSelect = ({ onChange }) => {
  const [ingredients, setIngredients] = useState([]);
  const [selectedIngredients, setSelectedIngredients] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getIngredients();
  }, []);

  const getIngredients = async () => {
    const ingredients = await getPizzaIngredients();
    setIngredients(ingredients);
    setLoading(false);
  };

  const ingredienSelected = ({ target: { checked, value } }) => {
    const ingredient = ingredients.find((ing) => ing.id === parseInt(value, 10));
    let newSelectedIngredients;

    if (checked) {
      newSelectedIngredients = [...selectedIngredients, ingredient];
    } else {
      newSelectedIngredients = selectedIngredients.filter(
        (ing) => ing.id !== parseInt(value, 10)
      );
    }

    setSelectedIngredients(newSelectedIngredients);
    onChange({ target: { name: 'ingredients', value: newSelectedIngredients } });
  };


  return (
    <div>
      <h3>Select ingredients</h3>
      {loading ? (
        <p>Ingredients loading...</p>
      ) : (
        ingredients.map((ing) => (
          <label key={ing.id}>
            <input
              type="checkbox"
              value={ing.id}
              onChange={ingredienSelected}
            />
            <span>{ing.name}</span>
          </label>
        ))
      )}
    </div>
  );
};

export default IngredientsSelect;
