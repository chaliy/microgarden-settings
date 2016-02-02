import { wireUpdate } from '../../utils/dc/wires';
import { redirectTo } from '../../utils/routing';

import api from '../api';
import SchemaForm from '../components/SchemaForm';

var Create = props => (
    <div>
      <h2>Schema: {props.displayName}</h2>
      <SchemaForm {...props} />
    </div>
);

export default wireUpdate({
  load: api.load,
  update: api.update,
  // update: (id, data) => {
  //   console.log(data);
  // },
  success: () => {
    redirectTo('/schemas');
  }
})(Create);
