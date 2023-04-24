import React from 'react';
import './PizzaItem.scss'
const PizzaItem = (props) => {
  const { pizza } = props;
  const pizzaSizes = ["Small", "Medium", "Large", "ExtraLarge"]
  return (
    <div className='pizza'>
      <img className='image' src={`data:image/png;base64,${pizza.image}`} alt={pizza.name}
      />
      <strong className='name'>{pizza.name}</strong>
      <p className='ingredients'> {pizza.ingredients.map(ingredient => ingredient.name).join(", ")}</p>
      <div className='sizes'>{pizzaSizes && pizzaSizes.map((size, index) =>
        <label key={index} className={`size ${size === pizza.pizzaSize ? 'selected' : null}`}>
          <input type='radio' checked={size === pizza.pizzaSize} />
          <span>{size}</span>
        </label>
      )}</div>
      <div className='pizza-bottom'>
        <strong className='price'>{pizza.price}$</strong>
        <button className='addButton'>Add to cart</button>
      </div>
    </div>
  );
}

export default PizzaItem;
