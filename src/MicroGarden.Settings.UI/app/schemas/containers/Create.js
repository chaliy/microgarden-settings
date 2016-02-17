import { wireCreate } from '../../utils/dc/wires';
import { redirectTo } from '../../utils/routing';

import api from '../api';
import SchemaForm from '../components/SchemaForm';

var Create = props => (
    <div>
      <h2>Create Schema</h2>
      <SchemaForm {...props} />
    </div>
);

export default wireCreate({
  create: api.create,
  success: () => {
    redirectTo('/schemas');
  }
})(Create);
