import { configureStore, ThunkAction, Action, combineReducers } from '@reduxjs/toolkit';
import { persistReducer, persistStore } from 'redux-persist';
import storage from 'redux-persist/es/storage';

import categoryReducer from './reducers/categoryReducer';
import orderItemReducer from './reducers/orderItemReducer';
import orderReducer from './reducers/orderReducer';
import productReducer from './reducers/productReducer';

const persistConfig = {
  key: 'root',
  storage
};

const rootReducer = combineReducers({
  categoryReducer,
  productReducer,
  orderItemReducer,
  orderReducer
})

const persistedReducer = persistReducer(persistConfig, rootReducer)

export const createStore = () => {
  return configureStore({
    reducer: persistedReducer
  })
}

export const store = createStore()
export const persistor = persistStore(store);
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
