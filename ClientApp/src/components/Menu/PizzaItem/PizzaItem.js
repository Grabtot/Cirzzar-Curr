import React, { useState } from 'react';
import './PizzaItem.scss'
const PizzaItem = (props) => {
  const { pizza, addToCart } = props;
  const pizzaSizes = ["Small", "Medium", "Large", "ExtraLarge"];
  const [selectedSize, setSelectedSize] = useState(pizzaSizes[0]);

  return (
    <div className='pizza'>
      <img className='image' src={`data:image/png;base64,${pizza.image}`} alt={pizza.name}
      />
      <strong className='name'>{pizza.name}</strong>
      <p className='ingredients'> {pizza.ingredients.map(ingredient => ingredient.name).join(", ")}</p>
      <div className='sizes'>{pizzaSizes && pizzaSizes.map((size, index) =>
        <label key={index} className={`size ${size === selectedSize ? 'selected' : null}`}>
          <input type='radio' checked={size === pizza.pizzaSize} onChange={() => setSelectedSize(size)} />
          <span>{size}</span>
        </label>
      )}</div>
      <div className='pizza-bottom'>
        <strong className='price'>{pizza.price}$</strong>
        <button className='addButton' onClick={() => addToCart({ product: pizza, selectedSize, quantity: 1 })}>Add to cart</button>
      </div>
    </div >
  );
}

export default PizzaItem;
