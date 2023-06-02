import React, { useEffect, useState } from 'react';
import { getPizzaIngredients } from '../../api-products/ProductsService';
import AddIcon from '@mui/icons-material/Add';
import { TextField } from '@mui/material';
import { addIngredient } from '../../api-products/ProductsService';

const IngredientsSelect = ({ onChange }) => {
  const [ingredients, setIngredients] = useState([]);
  const [addIngredientMode, setAddIngredientMode] = useState(false);
  const [newIngredient, setNewIngredient] = useState(baseIngredient);
  const [selectedIngredients, setSelectedIngredients] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getIngredients();
  }, [ingredients]);

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

  const addNewIngredient = (e) => {
    e.preventDefault();
    addIngredient(newIngredient);
    setAddIngredientMode(false);
    setIngredients(ingredients);
  }

  if (loading) {
    return <p>Ingredients loading...</p>
  }

  return (
    <div>
      <h3>Select ingredients</h3>
      <div> {ingredients.map((ing) => (
        <><label key={ing.id}>
          <input
            type="checkbox"
            value={ing.id}
            onChange={ingredienSelected}
          />
          <span>{ing.name}</span>
        </label><br /></>
      ))}
        <AddIcon color='success' onClick={() => setAddIngredientMode(true)} />
      </div>
      {
        addIngredientMode &&
        (<div>
          <TextField label="Name" name={'name'} onChange={({ target: { value } }) => setNewIngredient({ ...newIngredient, name: value })}></TextField>
          <button onClick={addNewIngredient}>Add</button>
        </div>)
      }
    </div >
  );
};

const baseIngredient = {
  name: "",
  image: null
}

export default IngredientsSelect;
